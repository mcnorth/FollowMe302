using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FollowMe302.scripts;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace FollowMe302
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        /// <summary>
        /// btnLoginPage_Click is an event triggered from the login button
        /// This is where the app gets the users input and checks against the database
        /// If a record is found it will load the page that was checked via the radio button
        /// </summary> 
        protected void btnLoginPage_Click(object sender, EventArgs e)
        {
           

            if (txtuserNameLogin.Text != string.Empty || txtpwdLogin.Text != string.Empty)
            {
                MemberEntity member = new MemberEntity();
                member.UserName = txtuserNameLogin.Text;
                member.Password = txtpwdLogin.Text;
                string followID = "";
                string hashedPasswordFromDatabase = "";
                byte[] hashedPasswordFromDatabaseBytesArray;
                byte[] hashedPasswordUserInputBytesArray;




                if (rdPersonal.Checked == true)
                {
                    SqlConnection con = new SqlConnection(@"Data Source=182.50.133.109; Database=FollowMe; Integrated Security=False; User ID=kellie; Password=rQp45a1^; Connect Timeout=15; Encrypt=False; Packet Size=4096");

                    //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|FollowMeDatabase.mdf; Integrated Security=True");

                    SqlDataReader rdr = null;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM [_User] WHERE [userName] = '" + member.UserName + "'", con);


                    con.Open();

                    rdr = cmd.ExecuteReader();
                    int dataCount = 0;
                    while (rdr.Read())
                    {
                        dataCount++;
                        followID = rdr["followMeId"].ToString();
                        hashedPasswordFromDatabase = rdr["password"].ToString();



                    }

                    //checks for user in the database
                    //adds a session if the user exists and redirects to userPage
                    if (dataCount > 0)
                    {
                        //turn the database password into bytes
                        hashedPasswordFromDatabaseBytesArray = Convert.FromBase64String(hashedPasswordFromDatabase);

                        hashedPasswordUserInputBytesArray = GetHashedPassword(member.Password, hashedPasswordFromDatabaseBytesArray);

                       
                        //loop to compare byte arrays
                        int ok = 1;

                        for(int i = 0; i < 20; i++)
                            if (hashedPasswordFromDatabaseBytesArray[i + 16] != hashedPasswordUserInputBytesArray[i])
                                ok = 0;

                        if(ok == 1)
                        {
                            Session["name"] = member.UserName;
                            Session["fmID"] = followID;
                            Response.Redirect("~/ClientDashboard.aspx");
                            Session.RemoveAll();
                        }
                        else
                        {
                            lblModalTitle.Text = "ERROR!";
                            lblModalBody.Text = "Incorrect username or password! Try again";
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                            upModal.Update();
                        }
                       
                    }
                    else
                    {
                        //lblLogStatus.Text = "Details incorrect or user does not exist. Try again";
                        lblModalTitle.Text = "ERROR!";
                        lblModalBody.Text = "Incorrect username or password! Try again";
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

                    SqlCommand cmd = new SqlCommand("SELECT * FROM [_Company] WHERE [companyName] = '" + member.UserName + "'", con);

                    con.Open();

                    rdr = cmd.ExecuteReader();
                    int dataCount = 0;

                    while (rdr.Read())
                    {
                        dataCount++;
                        followID = rdr["companyId"].ToString();
                        hashedPasswordFromDatabase = rdr["password"].ToString();
                    }

                    //checks for user in the database
                    //adds a session if the user exists and redirects to userPage
                    if (dataCount > 0)
                    {
                        //turn the database password into bytes
                        hashedPasswordFromDatabaseBytesArray = Convert.FromBase64String(hashedPasswordFromDatabase);

                        hashedPasswordUserInputBytesArray = GetHashedPassword(member.Password, hashedPasswordFromDatabaseBytesArray);


                        //loop to compare byte arrays
                        int ok = 1;

                        for (int i = 0; i < 20; i++)
                            if (hashedPasswordFromDatabaseBytesArray[i + 16] != hashedPasswordUserInputBytesArray[i])
                                ok = 0;

                        if (ok == 1)
                        {
                            Session["name"] = member.UserName;
                            Session["fmID"] = followID;
                            Response.Redirect("~/BusDashboard.aspx");
                            Session.RemoveAll();
                        }
                        else
                        {
                            lblModalTitle.Text = "ERROR!";
                            lblModalBody.Text = "Incorrect username or password! Try again";
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                            upModal.Update();
                        }

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
            else
            {
                //lblLogStatus.Text = "Password or username cannot be empty";
                lblModalTitle.Text = "ERROR!";
                lblModalBody.Text = "Password or username cannot be empty.";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }
        }

        public byte[] GetHashedPassword(string password, byte[] dbPass)
        {
            //remove salt from dbPass so we have the same salt value
            byte[] dbSalt = new byte[16];
            Array.Copy(dbPass, 0, dbSalt, 0, 16);
           
            //salt value from dbPass and password using PBKDF2
            var pbkdf2 = new Rfc2898DeriveBytes(password, dbSalt, 10000);

            //create byte array for hash, place the string in the byte array. GetBytes does this.
            // 20 is the length of the array in bytes
            byte[] hashPasswordUserInputMinusSalt = pbkdf2.GetBytes(20);
                        
            return hashPasswordUserInputMinusSalt;
        }

        


    }
}