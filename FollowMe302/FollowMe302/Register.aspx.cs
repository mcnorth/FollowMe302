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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegisterPage_Click(object sender, EventArgs e)
        {
            MemberEntity member = new MemberEntity();
            member.UserName = txtuserNameRegister.Text;
            member.Password = txtpwdRegister.Text;
            

            if(rdRegPersonal.Checked == true)
            {
                SqlConnection con = new SqlConnection(@"Data Source=182.50.133.109; Database=FollowMe; Integrated Security=False; User ID=kellie; Password=rQp45a1^; Connect Timeout=15; Encrypt=False; Packet Size=4096");

                //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|FollowMeDatabase.mdf; Integrated Security=True");

                SqlDataReader rdr = null;

                SqlCommand cmd = new SqlCommand("SELECT * FROM [_User] WHERE [userName] = '" + member.UserName + "'", con);
                SqlCommand insertCmd = new SqlCommand("INSERT INTO _User (userName, password)" +
                            "VALUES (@userName, @password)", con);

                con.Open();

                //checks for the username in the database from the command
                var nUserName = cmd.ExecuteScalar();

                if (nUserName != null)
                {
                    lblRegStatus.Text = "UserName already exists, please choose another";
                }
                else
                {
                    insertCmd.Parameters.Add("@userName", System.Data.SqlDbType.VarChar).Value = member.UserName;
                    insertCmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = member.Password;
                    

                    //con.Open();
                    insertCmd.ExecuteNonQuery();

                    //lblRegStatus.Text = "" + member.UserName + " Successfully added. Please log in.";

                    lblRegStatus.Text = "" + member.UserName + " Successfully added.";
                    PleaseLog.Text = "<a href='Login.aspx' runat='server'>Please Login</a>";
                }

                con.Close();
            }

            if(rdRegBusiness.Checked == true)
            {
                SqlConnection con = new SqlConnection(@"Data Source=182.50.133.109; Database=FollowMe; Integrated Security=False; User ID=kellie; Password=rQp45a1^; Connect Timeout=15; Encrypt=False; Packet Size=4096");

                //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|FollowMeDatabase.mdf; Integrated Security=True");

                SqlDataReader rdr = null;

                SqlCommand cmd = new SqlCommand("SELECT * FROM [_Company] WHERE [companyName] = '" + member.UserName + "'", con);
                SqlCommand insertCmd = new SqlCommand("INSERT INTO _Company (companyName, password)" +
                            "VALUES (@companyName, @password)", con);
                con.Open();

                //checks for the username in the database from the command
                var nUserName = cmd.ExecuteScalar();


                if (nUserName != null)
                {
                    lblRegStatus.Text = "Company Name already exists, please choose another";
                }
                else
                {
                    insertCmd.Parameters.Add("@companyName", System.Data.SqlDbType.VarChar).Value = member.UserName;
                    insertCmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = member.Password;
                    

                    //con.Open();
                    insertCmd.ExecuteNonQuery();

                    
                    //lblRegStatus.Text = "" + member.UserName + " Successfully added.";
                    

                    lblRegStatus.Text = "" + member.UserName + " Successfully added.";
                    PleaseLog.Text = "<a href='Login.aspx' runat='server'>Please Login</a>";
                }

                con.Close();
            }

            if(rdRegPersonal.Checked == false && rdRegBusiness.Checked == false)
            {
                lblRegStatus.Text = "Please check a user type.";
            }
        }
    }
}