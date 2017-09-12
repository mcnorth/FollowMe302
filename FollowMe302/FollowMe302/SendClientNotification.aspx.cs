using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FollowMe302.Csharp;
using System.Data.SqlClient;
using PostmarkDotNet;
using PostmarkDotNet.Model;
using System.IO;
using System.Threading.Tasks;
using PostmarkDotNet.Legacy;

namespace FollowMe302
{
    public partial class SendClientNotification : System.Web.UI.Page
    {
        /// <summary>
        /// Page load happens when the page is loaded
        /// This is where the session variables are added to string variables
        /// It uses an asp label to attach some text with the session variable
        /// </summary> 
        /// 

        /// <summary>
        /// This method also finds the followme id username from the database
        /// and adds it to the message area
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            string compUserName = Session["name"].ToString();
            string compFollowId = Session["fmID"].ToString();
            int sendId = Convert.ToInt32(Session["sendid"]);

            //adds the session variable
            lblSession.Text = "Hello " + compUserName;

            //sql connections and query
            SqlConnection con = new SqlConnection(@"Data Source=182.50.133.109; Database=FollowMe; Integrated Security=False; User ID=kellie; Password=rQp45a1^; Connect Timeout=15; Encrypt=False; Packet Size=4096");

            //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|FollowMeDatabase.mdf; Integrated Security=True");

            SqlDataReader rdr = null;
            SqlCommand cmd = new SqlCommand("SELECT userName FROM [_User] WHERE [followMeId] = '" + sendId + "'", con);

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


        /// <summary>
        /// btnSendMyProfile_Click is an event that is fired when the send button is clicked
        /// It adds a record to the notification table (user id and company name)
        /// </summary> 
        //protected async void btnSendMyProfile_Click(object sender, EventArgs e)
        public void btnSendMyProfile_Click(object sender, EventArgs e)
        {
            if (Session["sendid"] != null)
            {
                string bus = Session["name"].ToString();
                int id = Convert.ToInt32(Session["sendid"]);

                bool res = SendEmail();
                //res.Wait();
                
                
                if(res == true)
                {
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

                    //lblSendStatus.Text = "Your notification has been sent";
                    lblModalTitle.Text = "CONGRATULATIONS!";
                    lblModalBody.Text = "Your notification has been sent";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                    upModal.Update();
                }
                else
                {
                    //lblSendStatus.Text = "No client to send notification to.";
                    lblModalTitle.Text = "ERROR!";
                    lblModalBody.Text = "No client to send notification to.";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                    upModal.Update();
                }
            }
            else
            {
                //lblEmailStatus.Text = "Your email has NOT been sent";
                lblModalTitle.Text = "ERROR!";
                lblModalBody.Text = "Email has not been sent";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }




        }

        /// <summary>
        /// Send Email is a method for sending an email
        /// This is how the app integrates with Postmark API to send a message from teh send notification page
        /// It shows a bootstrap modal for either fails and success.
        /// </summary>
        public bool SendEmail()
        {
            // Send an email asynchronously:
            var message = new PostmarkMessage()
            {
                To = "followmesit302@gmail.com",
                From = "kellie@kelliemcnaughton.com",
                TrackOpens = true,
                Subject = "A complex email",
                TextBody = "Plain Text Body",
                HtmlBody = "<html><body><p>A new notification has arrived.</p></body></html>",
                Tag = "New Year's Email Campaign",
                Headers = new HeaderCollection
                    {
                        { "X-CUSTOM-HEADER", "Header content"}
                    }
            };

            //var imageContent = File.ReadAllBytes("test.jpg");
            //message.AddAttachment(imageContent, "test.jpg", "image/jpg", "cid:embed_name.jpg");

            PostmarkClient client = new PostmarkClient("efc7197a-4c0d-4f4b-92f7-43c612ed74b1");
            PostmarkResponse response = client.SendMessage(message);


            if (response.Status != PostmarkStatus.Success)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}