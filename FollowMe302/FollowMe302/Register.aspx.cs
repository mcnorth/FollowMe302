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

        /// <summary>
        /// btnRegisterPage_Click is an event triggered from the register button
        /// This is where the app gets the users input and checks against the database
        /// If a record is found it will advise the user to choose a different username
        /// If record is not found the app will update the database table and advise the user to log in
        /// </summary> 
        protected void btnRegisterPage_Click(object sender, EventArgs e)
        {
            MemberEntity member = new MemberEntity();
            member.UserName = txtuserNameRegister.Text;
            member.Password = txtpwdRegister.Text;
            member.Email = txtemailRegister.Text;
            

            if(rdRegPersonal.Checked == true)
            {
                SqlConnection con = new SqlConnection(@"Data Source=182.50.133.109; Database=FollowMe; Integrated Security=False; User ID=kellie; Password=rQp45a1^; Connect Timeout=15; Encrypt=False; Packet Size=4096");

                //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|FollowMeDatabase.mdf; Integrated Security=True");

                SqlDataReader rdr = null;

                SqlCommand cmd = new SqlCommand("SELECT * FROM [_User] WHERE [userName] = '" + member.UserName + "'", con);
                SqlCommand insertCmd = new SqlCommand("INSERT INTO _User (userName, password, email)" +
                            "VALUES (@userName, @password, @email)", con);

                con.Open();

                //checks for the username in the database from the command
                var nUserName = cmd.ExecuteScalar();

                if (nUserName != null)
                {
                    //lblRegStatus.Text = "UserName already exists, please choose another";
                    lblModalTitle.Text = "ERROR!";
                    lblModalBody.Text = "User Name already exists, please choose another";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                    upModal.Update();
                }
                if (txtuserNameRegister.Text == "" || txtpwdRegister.Text == "") 
                {
                    lblModalTitle.Text = "ERROR!";
                    lblModalBody.Text = "User name / Password cannot be empty.";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                    upModal.Update();
                }
                else
                {
                    insertCmd.Parameters.Add("@userName", System.Data.SqlDbType.VarChar).Value = member.UserName;
                    insertCmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = member.Password;
                    insertCmd.Parameters.Add("@email", System.Data.SqlDbType.VarChar).Value = member.Email;


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
                SqlCommand insertCmd = new SqlCommand("INSERT INTO _Company (companyName, password, email)" +
                            "VALUES (@companyName, @password, @email)", con);
                con.Open();

                //checks for the username in the database from the command
                var nUserName = cmd.ExecuteScalar();


                if (nUserName != null)
                {
                    //lblRegStatus.Text = "Company Name already exists, please choose another";
                    lblModalTitle.Text = "ERROR!";
                    lblModalBody.Text = "Company Name already exists, please choose another";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                    upModal.Update();
                }
                if (txtuserNameRegister.Text == "" || txtpwdRegister.Text == "")
                {
                    lblModalTitle.Text = "ERROR!";
                    lblModalBody.Text = "Company name / Password cannot be empty.";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                    upModal.Update();
                }
                else
                {
                    insertCmd.Parameters.Add("@companyName", System.Data.SqlDbType.VarChar).Value = member.UserName;
                    insertCmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = member.Password;
                    insertCmd.Parameters.Add("@email", System.Data.SqlDbType.VarChar).Value = member.Email;


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
                //lblRegStatus.Text = "Please check a user type.";
                lblModalTitle.Text = "ERROR!";
                lblModalBody.Text = "Please check a user type.";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }
        }
    }
}