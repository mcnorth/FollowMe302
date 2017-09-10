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
    public partial class BusDashboard : System.Web.UI.Page
    {
        public string followId { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            string compUserName = Session["name"].ToString();
            string compFollowId = Session["fmID"].ToString();

            //adds the session variable
            lblSession.Text = "Hello " + compUserName;

            List<int> clientId = new List<int>();

            //creates connection and queries
            SqlConnection con = new SqlConnection(@"Data Source=182.50.133.109; Database=FollowMe; Integrated Security=False; User ID=kellie; Password=rQp45a1^; Connect Timeout=15; Encrypt=False; Packet Size=4096");

            //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|FollowMeDatabase.mdf; Integrated Security=True");

            SqlDataReader rdr = null;

            //creates command
            SqlCommand cmd = new SqlCommand("SELECT * FROM _Notifications WHERE companyName = '" + compUserName + "'", con);

            //checks the database to see if user exists
            con.Open();
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                clientId.Add((int)rdr["followMeId"]);
            }
            con.Close();

            if (clientId.Count > 0)
            {
                for (int i = 0; i < clientId.Count; i++)
                {
                    followId = Convert.ToString(clientId[i]);
                    Label lblNot = new Label();
                    lblNot.Text = "New updated details from " + followId + "<br /><br />";
                    lblNot.ID = "notif" + clientId[i];
                    notifPanel.Controls.Add(lblNot);
                    Session["clientsID"] = clientId[i];
                    Button btn = new Button();
                    btn.ID = "view" + clientId[i];
                    btn.Attributes.Add("class", "btn btn-primary btn-sm fBtn");
                    btn.Text = "View";
                    btn.Attributes.Add("style", "margin:5px");
                    btn.Click += new EventHandler(btnView_Click);
                    notifPanel.Controls.Add(btn);
                    Button btn2 = new Button();
                    btn2.ID = followId;
                    btn2.Attributes.Add("class", "btn btn-primary btn-sm fBtn");
                    btn2.Text = "Delete";
                    btn2.Click += new EventHandler(btnDelete_Click);
                    notifPanel.Controls.Add(btn2);
                    Label lblBreak = new Label();
                    lblBreak.Text = "<br /><br />";
                    lblBreak.ID = "break" + clientId[i];
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

        private void btnView_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GetClientDetails.aspx");
            //Button btn = (Button)sender;
            //string btnID = btn.ID;
            //Response.Redirect("~/client.aspx?field1="+ btnID);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string btnID = btn.ID;

            //creates connection and queries
            SqlConnection con = new SqlConnection(@"Data Source=182.50.133.109; Database=FollowMe; Integrated Security=False; User ID=kellie; Password=rQp45a1^; Connect Timeout=15; Encrypt=False; Packet Size=4096");

            //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|FollowMeDatabase.mdf; Integrated Security=True");

            SqlDataReader rdr = null;

            //creates command
            SqlCommand cmd = new SqlCommand("DELETE FROM _Notifications WHERE companyName = '" + Session["name"] + "' AND followMeId = '" + Convert.ToInt32(btnID) + "'", con);

            //checks the database to see if user exists
            con.Open();
            rdr = cmd.ExecuteReader();
            con.Close();

            Response.Redirect(Request.RawUrl);

        }
    }
}