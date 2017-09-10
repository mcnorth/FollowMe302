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
        protected void Page_Load(object sender, EventArgs e)
        {
            string clientUserName = Session["name"].ToString();
            string clientFollowId = Session["fmID"].ToString();

            //adds the session variable
            lblSession.Text = "Hello " + clientUserName;

            //sql connections and query
            SqlConnection con = new SqlConnection(@"Data Source=182.50.133.109; Database=FollowMe; Integrated Security=False; User ID=kellie; Password=rQp45a1^; Connect Timeout=15; Encrypt=False; Packet Size=4096");

            //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|FollowMeDatabase.mdf; Integrated Security=True");

            SqlDataReader rdr = null;
            SqlCommand cmd = new SqlCommand("SELECT * FROM [_UserDetails] WHERE [userName] = '" + clientUserName + "'", con);

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
                    txtViewEmail.Text = (string)rdr["email"];
                    txtViewUsername.Text = (string)rdr["userName"];
                    txtViewFirstName.Text = (string)rdr["firstName"];
                    txtViewLastName.Text = (string)rdr["lastName"];

                    lblViewStatus.Text = "Details that exist.";
                    

                }

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
                txtViewEmail.Text = "";
                txtViewUsername.Text = "";
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