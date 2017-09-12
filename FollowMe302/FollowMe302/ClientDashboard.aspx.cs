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
    public partial class ClientDashboard : System.Web.UI.Page
    {
        /// <summary>
        /// Page load happens when the page is loaded
        /// This is where the app checks the database table for existing notifications
        /// For each notification it finds, it will dynamically a delete button
        /// </summary> 
        protected void Page_Load(object sender, EventArgs e)
        {
            string clientUserName = Session["name"].ToString();
            string clientFollowId = Session["fmID"].ToString();

            //adds the session variable
            lblSession.Text = "Hello " + clientUserName;

            List<string> compName = new List<string>();

            //creates connection and queries
            SqlConnection con = new SqlConnection(@"Data Source=182.50.133.109; Database=FollowMe; Integrated Security=False; User ID=kellie; Password=rQp45a1^; Connect Timeout=15; Encrypt=False; Packet Size=4096");

            //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|FollowMeDatabase.mdf; Integrated Security=True");

            SqlDataReader rdr = null;

            //creates command
            SqlCommand cmd = new SqlCommand("SELECT * FROM _NotificationsToClient WHERE followMeId = '" + clientFollowId + "'", con);

            //checks the database to see if user exists
            con.Open();
            rdr = cmd.ExecuteReader();

            //add the company names to a list
            while (rdr.Read())
            {

                compName.Add((string)rdr["companyName"]);
            }
            con.Close();

            if (compName.Count > 0)
            {
                for (int i = 0; i < compName.Count; i++)
                {
                    string followId = Session["fmID"].ToString();


                    Label lblNot = new Label();
                    lblNot.Text = "Your details have been update from " + compName[i] + "<br /><br />";
                    lblNot.ID = "notif" + compName[i];
                    notifPanel.Controls.Add(lblNot);
                    //Session["clientsID"] = clientId[i];
                    Button btn2 = new Button();
                    btn2.ID = compName[i];
                    btn2.Attributes.Add("class", "btn btn-primary btn-sm fBtn");
                    btn2.Text = "Delete";
                    btn2.Click += new EventHandler(btnDelete_Click);                    
                    notifPanel.Controls.Add(btn2);
                    Label lblBreak = new Label();
                    lblBreak.Text = "<br /><br />";
                    lblBreak.ID = "break" + compName[i];
                    notifPanel.Controls.Add(lblBreak);

                }

            }
            else
            {
                Label lblNot = new Label();
                lblNot.Text = "No notifications";
                notifPanel.Controls.Add(lblNot);

            }

        }

        /// <summary>
        /// btnDelete_Click event for the delete button
        /// It takes the id from the button, and checks against the database
        /// Deletes the record from teh database table
        /// Reloads the page
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string btnID = btn.ID;

            //creates connection and queries
            SqlConnection con = new SqlConnection(@"Data Source=182.50.133.109; Database=FollowMe; Integrated Security=False; User ID=kellie; Password=rQp45a1^; Connect Timeout=15; Encrypt=False; Packet Size=4096");

            //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|FollowMeDatabase.mdf; Integrated Security=True");

            SqlDataReader rdr = null;

            //creates command
            SqlCommand cmd = new SqlCommand("DELETE FROM _NotificationsToClient WHERE companyName = '" + btnID + "' AND followMeId = '" + Session["fmID"] + "'", con);

            //checks the database to see if user exists
            con.Open();
            rdr = cmd.ExecuteReader();
            con.Close();

            Response.Redirect(Request.RawUrl);


        }
    }
}