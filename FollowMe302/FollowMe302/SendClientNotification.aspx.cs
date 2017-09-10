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
    public partial class SendClientNotification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string compUserName = Session["name"].ToString();
            string compFollowId = Session["fmID"].ToString();

            //adds the session variable
            lblSession.Text = "Hello " + compUserName;

            if (Session["clientsID"] != null)
            {

                //sql connections and query
                SqlConnection con = new SqlConnection(@"Data Source=182.50.133.109; Database=FollowMe; Integrated Security=False; User ID=kellie; Password=rQp45a1^; Connect Timeout=15; Encrypt=False; Packet Size=4096");

                //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|FollowMeDatabase.mdf; Integrated Security=True");

                SqlDataReader rdr = null;
                SqlCommand cmd = new SqlCommand("SELECT userName FROM [_User] WHERE [followMeId] = '" + Session["clientsID"] + "'", con);

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
                        txtProComment.Text = "Hello " + (string)rdr["userName"] + " Your details have been updated in our system Regards " + Session["name"];
                    }

                }

                //if no records found leaves the text boxes blank
                else
                {
                    txtProComment.Text = "";
                }

                con.Close();
            }
            else
            {
                txtProComment.Text = "";
            }
        }

        protected void btnSendMyProfile_Click(object sender, EventArgs e)
        {
            if (Session["clientsID"] != null)
            {
                string bus = Session["name"].ToString();
                int id = Convert.ToInt32(Session["clientsID"]);

                //creates connection and query
                SqlConnection con = new SqlConnection(@"Data Source=182.50.133.109; Database=FollowMe; Integrated Security=False; User ID=kellie; Password=rQp45a1^; Connect Timeout=15; Encrypt=False; Packet Size=4096");

                //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|FollowMeDatabase.mdf; Integrated Security=True");

                SqlDataReader rdr = null;

                SqlCommand cmd = new SqlCommand("INSERT INTO [_NotificationsToClient] (companyName, followMeId) VALUES ('" + bus + "', '" + id + "')", con);

                // SqlCommand insertCmd = new SqlCommand("INSERT INTO _NotificationsToClient (followMeId, companyName)" +
                //"VALUES (@followMeId, @companyName)", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                lblSendStatus.Text = "Your notification has been sent";
            }
            else
            {
                lblSendStatus.Text = "No client to send notification to.";
            }
        }
    }
}