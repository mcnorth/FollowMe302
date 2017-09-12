using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FollowMe302.Csharp;
using System.Data.SqlClient;


namespace FollowMe302
{
    public partial class SendProfile : System.Web.UI.Page
    {
        /// <summary>
        /// Page load happens when the page is loaded
        /// This is where the session variables are added to string variables
        /// It uses an asp label to attach some text with the session variable
        /// </summary> 
        /// 

        /// <summary>
        /// This method also finds the followme id username from the database
        /// and adds the selected records to the textboxes only if the user exists.
        /// If not a error message pop up.
        /// It also dynamically adds the company names in the database to a select menu list items
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            string clientUserName = Session["name"].ToString();
            string clientFollowId = Session["fmID"].ToString();
            

            //adds the session variable
            lblSession.Text = "Hello " + clientUserName;

            //create list
            List<string> coNames = new List<string>();

            //creates connection and query
            SqlConnection con = new SqlConnection(@"Data Source=182.50.133.109; Database=FollowMe; Integrated Security=False; User ID=kellie; Password=rQp45a1^; Connect Timeout=15; Encrypt=False; Packet Size=4096");

            //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|FollowMeDatabase.mdf; Integrated Security=True");

            SqlDataReader rdr = null;
            SqlDataReader rdrDD = null;
            SqlCommand cmd = new SqlCommand("SELECT * FROM [_UserDetails] WHERE [userName] = '" + clientUserName + "'", con);
            SqlCommand cmdDD = new SqlCommand("SELECT companyName FROM _Company", con);

            //checks user exists
            con.Open();
            rdr = cmd.ExecuteReader();
            int dataCount = 0;
            while (rdr.Read())
            {
                dataCount++;
            }
            con.Close();

            //if user exists add the user information to the text boxes
            if (dataCount > 0)
            {
                con.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {


                    txtSendHouseNo.Text = (string)rdr["houseNumber"];
                    txtSendStreet.Text = (string)rdr["streetName"];
                    txtSendSuburb.Text = (string)rdr["suburb"];
                    txtSendState.Text = (string)rdr["stat"];
                    txtSendCountry.Text = (string)rdr["country"];
                    txtSendPostcode.Text = (string)rdr["postcode"];
                    txtSendEmail.Text = (string)rdr["email"];
                    txtSendFirstName.Text = (string)rdr["firstName"];
                    txtSendLastName.Text = (string)rdr["lastName"];
                    txtSendFollowId.Text = clientFollowId;


                }

            }

            //if user doesnt exist leave blank
            else
            {
                txtSendHouseNo.Text = "";
                txtSendStreet.Text = "";
                txtSendSuburb.Text = "";
                txtSendState.Text = "";
                txtSendCountry.Text = "";
                txtSendPostcode.Text = "";
                txtSendEmail.Text = "";
                txtSendFirstName.Text = "";
                txtSendLastName.Text = "";
                txtSendFollowId.Text = clientFollowId;
                lblSendStatus.Text = "Please add your details.";
            }

            con.Close();

            con.Open();
            rdrDD = cmdDD.ExecuteReader();

            while (rdrDD.Read())
            {
                coNames.Add((string)rdrDD["companyName"]);

            }
            con.Close();

            

            foreach (var item in coNames)
            {

                ddlSendPro.Items.Add(new ListItem(item));
            }
        }

        /// <summary>
        /// btnSendMyProfile_Click is an event fired by the send button
        /// It takes the company name selected and adds it to the notifications table
        /// If not a error message pop up.
        /// It also dynamically adds the company names in the database to a select menu list items
        /// </summary>
        protected void btnSendMyProfile_Click(object sender, EventArgs e)
        {
            //varible for drop down list
            string selBusiness = ddlSendPro.SelectedItem.Text;
            List<string> cName = new List<string>();
            string fID = Convert.ToString(Session["fmID"]);
            

            //creates connection and query
            SqlConnection con = new SqlConnection(@"Data Source=182.50.133.109; Database=FollowMe; Integrated Security=False; User ID=kellie; Password=rQp45a1^; Connect Timeout=15; Encrypt=False; Packet Size=4096");

            //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|FollowMeDatabase.mdf; Integrated Security=True");

            SqlDataReader rdr = null;

            SqlCommand cmd = new SqlCommand("SELECT * FROM [_Notifications] WHERE [companyName] = '" + selBusiness + "' AND [followMeId] = '" + fID + "'", con);
            SqlCommand cmdIn = new SqlCommand("INSERT INTO [_Notifications] (followMeId, companyName) SELECT _User.followMeId, _Company.companyName FROM [_User], _Company WHERE userName = '" + Session["name"] + "' AND companyName = '" + selBusiness + "'", con);

            if (ddlSendPro.SelectedItem.Text == " " || ddlSendPro.SelectedItem.Text == "Choose...")
            {
                //lblSendStatus.Text = "Please select a business.";
                lblModalTitle.Text = "ERROR";
                lblModalBody.Text = "Please select a business.";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }
            else
            {

                con.Open();
                rdr = cmd.ExecuteReader();
                //int dataCount = 0;

                while (rdr.Read())
                {

                    cName.Add((string)rdr["companyName"]);
                }
                con.Close();

                if (cName.Count > 0)
                {
                    
                    //lblSendStatus.Text = "You have already sent your details to this business";
                    lblModalTitle.Text = "ERROR";
                    lblModalBody.Text = "You have already sent your details to this company.";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                    upModal.Update();

                }
                else
                {
                    con.Open();
                    cmdIn.ExecuteNonQuery();
                    con.Close();
                    //lblSendStatus.Text = "Your details have been sent.";
                    lblModalTitle.Text = "CONGRATULATIONS!";
                    lblModalBody.Text = "Your details have been sent.";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                    upModal.Update();
                }

                
            }
            
        }

        protected void MycloseWindow(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// btnClose_Click is an event fired by the close button on the modal pop up
        /// It removes all the company names from the select menu item list and reloads the page
        /// Doing this prevents it from loading the names again and appending to the list.
        /// </summary>
        protected void btnClose_Click(object sender, EventArgs e)
        {
            ddlSendPro.Items.Clear();
            Response.Redirect("~/SendProfile.aspx");
        }
    }
}