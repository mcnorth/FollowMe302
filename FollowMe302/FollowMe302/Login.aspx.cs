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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoginPage_Click(object sender, EventArgs e)
        {
            

            MemberEntity member = new MemberEntity();
            member.UserName = txtuserNameLogin.Text;
            member.Password = txtpwdLogin.Text;
            string followID = "";

            

            if (rdPersonal.Checked == true)
            {
                SqlConnection con = new SqlConnection(@"Data Source=182.50.133.109; Database=FollowMe; Integrated Security=False; User ID=kellie; Password=rQp45a1^; Connect Timeout=15; Encrypt=False; Packet Size=4096");

                //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|FollowMeDatabase.mdf; Integrated Security=True");

                SqlDataReader rdr = null;

                SqlCommand cmd = new SqlCommand("SELECT * FROM [_User] WHERE [userName] = '" + member.UserName + "' AND [password] = '" + member.Password + "'", con);
                SqlCommand insertCmd = new SqlCommand("INSERT INTO _User (userName, password, email)" +
                            "VALUES (@userName, @password, @email)", con);

                con.Open();

                rdr = cmd.ExecuteReader();
                int dataCount = 0;
                while (rdr.Read())
                {
                    dataCount++;
                    followID = rdr["followMeId"].ToString();
                }

                //checks for user in the database
                //adds a session if the user exists and redirects to userPage
                if (dataCount > 0)
                {
                    Session["name"] = member.UserName;
                    Session["fmID"] = followID;
                    Response.Redirect("~/ClientDashboard.aspx");
                    Session.RemoveAll();
                }
                else
                {
                    //lblLogStatus.Text = "Details incorrect or user does not exist. Try again";
                    lblModalTitle.Text = "ERROR!";
                    lblModalBody.Text = "Details incorrect or user does not exist. Try again";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                    upModal.Update();
                }

                con.Close();
            }

            if (rdBusiness.Checked == true)
            {
                SqlConnection con = new SqlConnection(@"Data Source=182.50.133.109; Database=FollowMe; Integrated Security=False; User ID=kellie; Password=rQp45a1^; Connect Timeout=15; Encrypt=False; Packet Size=4096");

                //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|FollowMeDatabase.mdf; Integrated Security=True");

                SqlDataReader rdr = null;

                SqlCommand cmd = new SqlCommand("SELECT * FROM [_Company] WHERE [companyName] = '" + member.UserName + "' AND [password] = '" + member.Password + "'", con);

                con.Open();

                rdr = cmd.ExecuteReader();
                int dataCount = 0;

                while (rdr.Read())
                {
                    dataCount++;
                    followID = rdr["companyId"].ToString();
                }

                //checks for user in the database
                //adds a session if the user exists and redirects to userPage
                if (dataCount > 0)
                {
                    Session["name"] = member.UserName;
                    Session["fmID"] = followID;
                    Response.Redirect("~/BusDashboard.aspx");
                    Session.RemoveAll();
                }
                else
                {
                    //lblLogStatus.Text = "Details incorrect or user does not exist. Try again";
                    lblModalTitle.Text = "ERROR!";
                    lblModalBody.Text = "Details incorrect or user does not exist. Try again";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                    upModal.Update();
                }

                con.Close();
            }

            if (rdPersonal.Checked == false && rdBusiness.Checked == false)
            {
                //lblLogStatus.Text = "Please check a user type.";
                lblModalTitle.Text = "ERROR!";
                lblModalBody.Text = "Please check a user type.";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();

            }
        }

        
    }
}