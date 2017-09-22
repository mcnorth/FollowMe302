using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FollowMe302.scripts;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Security.Cryptography;

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
            int ResultsPassword = 0;
            int ResultsUserName = 0;
            int ResultsEmail = 0;

            if (txtuserNameRegister.Text != string.Empty || txtpwdRegister.Text != string.Empty || txtemailRegister.Text != string.Empty)
            {
                ResultsPassword = Validate_Password(txtpwdRegister.Text);
                ResultsUserName = Validate_UserName(txtuserNameRegister.Text);
                ResultsEmail = Validate_Email(txtemailRegister.Text);

                if(ResultsPassword == 0)
                {
                    lblModalTitle.Text = "ERROR!";
                    lblModalBody.Text = "Invalid password. Must have: One uppercase letter, One lowercase letter, One number, One special character, Between 8 - 15 characters long.";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                    upModal.Update();
                }
                
                if (ResultsUserName == 0)
                {
                    lblModalTitle.Text = "ERROR!";
                    lblModalBody.Text = "Invalid username.\nMust have: One letter, One number, Between 8 - 15 characters long.";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                    upModal.Update();
                }                

                if (ResultsEmail == 0)
                {
                    lblModalTitle.Text = "ERROR!";
                    lblModalBody.Text = "Invalid email format";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                    upModal.Update();
                }
                
                if (ResultsPassword == 1 && ResultsUserName == 1 && ResultsEmail == 1)
                {
                    SubmitDetails();
                }

            }
            else
            {
                lblModalTitle.Text = "ERROR!";
                lblModalBody.Text = "User Name, Email or Password cannot be empty";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }

            
        }

        public void SubmitDetails()
        {
            string hashedPassword = "";
            MemberEntity member = new MemberEntity();
            member.UserName = txtuserNameRegister.Text;
            member.Password = txtpwdRegister.Text;
            member.Email = txtemailRegister.Text;


            if (rdRegPersonal.Checked == true)
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
                else
                {
                    hashedPassword = GetHashedPassword(member.Password);

                    insertCmd.Parameters.Add("@userName", System.Data.SqlDbType.VarChar).Value = member.UserName;
                    insertCmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = hashedPassword;
                    insertCmd.Parameters.Add("@email", System.Data.SqlDbType.VarChar).Value = member.Email;


                    //con.Open();
                    insertCmd.ExecuteNonQuery();

                    //lblRegStatus.Text = "" + member.UserName + " Successfully added. Please log in.";

                    lblRegStatus.Text = "" + member.UserName + " Successfully added.";
                    PleaseLog.Text = "<a href='Login.aspx' runat='server'>Please Login</a>";
                }

                con.Close();
            }
            if (rdRegBusiness.Checked == true)
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
                else
                {
                    hashedPassword = GetHashedPassword(member.Password);
                    insertCmd.Parameters.Add("@companyName", System.Data.SqlDbType.VarChar).Value = member.UserName;
                    insertCmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = hashedPassword;
                    insertCmd.Parameters.Add("@email", System.Data.SqlDbType.VarChar).Value = member.Email;


                    //con.Open();
                    insertCmd.ExecuteNonQuery();


                    //lblRegStatus.Text = "" + member.UserName + " Successfully added.";


                    lblRegStatus.Text = "" + member.UserName + " Successfully added.";
                    PleaseLog.Text = "<a href='Login.aspx' runat='server'>Please Login</a>";
                }

                con.Close();
            }

            if (rdRegPersonal.Checked == false && rdRegBusiness.Checked == false)
            {
                //lblRegStatus.Text = "Please check a user type.";
                lblModalTitle.Text = "ERROR!";
                lblModalBody.Text = "Please check a user type.";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }
        }

        public string GetHashedPassword(string password)
        {
            //create byte array for salt
            byte[] salt;

            //generate salt
            //16 is the length of the array
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            //hash and salt password using PBKDF2
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);

            //create byte array for hash, place the string in the byte array. GetBytes does this.
            // 20 is the length of the array in bytes
            byte[] hash = pbkdf2.GetBytes(20);

            //create new byte array to hold the hash salt+password.
            //36 is length because 20 for hash and 16 for salt
            byte[] hashBytes = new byte[36];

            //place the hash and salt in their places. Salt first, hash second
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            //convert the array to a string
            string passwordHash = Convert.ToBase64String(hashBytes);

            return passwordHash;
        }

        public int Validate_Password(string Password)
        {
            //8 -15 chars long, at least 1 number, 1 uppercase, 1 lowercase 1 special char
            var matchpassword = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");
            if (matchpassword.IsMatch(Password))
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }

        public int Validate_UserName(string UserName)
        {
            //letters , numbers between 8 and 15 chars long
            var matchusername = new Regex(@"\w{8,15}");
            if (matchusername.IsMatch(UserName))
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }

        public int Validate_Email(string Email)
        {
            //letters , numbers between 8 and 15 chars long
            var matchemail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (matchemail.IsMatch(Email))
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }
    }
}