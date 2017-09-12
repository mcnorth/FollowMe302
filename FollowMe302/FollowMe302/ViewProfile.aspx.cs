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
    public partial class ViewProfile : System.Web.UI.Page
    {
        /// <summary>
        /// Page load happens when the page is loaded
        /// This is where the session variables are added to string variables
        /// It uses an asp label to attach some text with the session variable
        /// </summary> 
        /// 

        /// <summary>
        /// This method also finds the followme id company from the database
        /// and adds the selected records to the textboxes only if the user exists.
        /// If not a error message pop up.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            string clientUserName = Session["name"].ToString();
            string clientFollowId = Session["fmID"].ToString();

            int id = Convert.ToInt32(Session["fmID"]);

            //adds the session variable
            lblSession.Text = "Hello " + clientUserName;

            //sql connections and query
            SqlConnection con = new SqlConnection(@"Data Source=182.50.133.109; Database=FollowMe; Integrated Security=False; User ID=kellie; Password=rQp45a1^; Connect Timeout=15; Encrypt=False; Packet Size=4096");

            //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|FollowMeDatabase.mdf; Integrated Security=True");

            SqlDataReader rdr = null;
            SqlDataReader rdr2 = null;
            SqlCommand cmd = new SqlCommand("SELECT * FROM [_UserDetails] WHERE [followMeId] = '" + id + "'", con);

            SqlCommand cmd2 = new SqlCommand("SELECT * FROM [_User] WHERE [followMeId] = '" + id + "'", con);

            //opens connection reads the database as per the query
            //counts how many rows and adds to the variable datacount
            con.Open();
            rdr = cmd.ExecuteReader();
            int dataCount = 0;
            while (rdr.Read())
            {
                dataCount++;
            }
            con.Close();

            //if one row found reads the database annd adds the records to the specific text boxes
            if (dataCount > 0)
            {
                con.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtViewHouseNo.Text = (string)rdr["houseNumber"];
                    txtViewStreet.Text = (string)rdr["streetName"];
                    txtViewSuburb.Text = (string)rdr["suburb"];
                    txtViewState.Text = (string)rdr["stat"];
                    txtViewCountry.Text = (string)rdr["country"];
                    txtViewPostcode.Text = (string)rdr["postcode"];
                    txtViewPhoneNumber.Text = (string)rdr["phoneNumber"];
                    txtViewFirstName.Text = (string)rdr["firstName"];
                    txtViewLastName.Text = (string)rdr["lastName"];

                    
                }
                con.Close();

                con.Open();
                rdr = cmd2.ExecuteReader();
                while (rdr.Read())
                {

                    txtViewEmail.Text = (string)rdr["email"];

                }

                lblViewStatus.Text = "Details that exist.";
            }

            //if no records found leaves the text boxes blank
            else
            {
                txtViewHouseNo.Text = "";
                txtViewStreet.Text = "";
                txtViewSuburb.Text = "";
                txtViewState.Text = "";
                txtViewCountry.Text = "";
                txtViewPostcode.Text = "";
                txtViewPhoneNumber.Text = "";
                txtViewEmail.Text = "";
                txtViewFirstName.Text = "";
                txtViewLastName.Text = "";

                //lblViewStatus.Text = "Details do not exist.";
                lblModalTitle.Text = "ERROR!";
                lblModalBody.Text = "Details do not exist.";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }

            con.Close();
            
        }
    }
}