using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FollowMe302.scripts;
using System.Data.SqlClient;

namespace FollowMe302
{
    public partial class EditCompanyDetails : System.Web.UI.Page
    {
        /// <summary>
        /// Page load happens when the page is loaded
        /// This is where the session variables are added to string variables
        /// It uses an asp label to attach some text with the session variable
        /// </summary> 
        protected void Page_Load(object sender, EventArgs e)
        {
            string compUserName = Session["name"].ToString();
            string compFollowId = Session["fmID"].ToString();

            //adds the session variable
            lblSession.Text = "Hello " + compUserName;
        }

        /// <summary>
        /// btnEditCoDetails_Click is the event from the update button
        /// This is where the app takes the user input from teh textboxes
        /// It then checks the database table [company details] for existing records
        /// If record is found it will modify the existing data
        /// If records are not found it will update the table
        /// </summary> 
        protected void btnEditCoDetails_Click(object sender, EventArgs e)
        {
            string compName = Session["name"].ToString();
            //adds user input from the text boxes to an object
            MemberEntity member = new MemberEntity();
            member.CompanyRep = txtEditRepName.Text;
            member.PhoneNumber = txtEditPhoneNumber.Text;
            member.Address = txtEditAddress.Text;
            member.Suburb = txtEditSuburb.Text;
            member.Postcode = txtEditPostcode.Text;

            //creates connection and queries
            SqlConnection con = new SqlConnection(@"Data Source=182.50.133.109; Database=FollowMe; Integrated Security=False; User ID=kellie; Password=rQp45a1^; Connect Timeout=15; Encrypt=False; Packet Size=4096");

            //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|FollowMeDatabase.mdf; Integrated Security=True");

            SqlDataReader rdr = null;


            SqlCommand cmd = new SqlCommand("SELECT * FROM [_CompanyDetails] WHERE [companyId] = '" + Session["fmID"] + "'", con);

            SqlCommand modify = new SqlCommand("UPDATE _CompanyDetails SET companyRep=@companyRep, phoneNumber=@phoneNumber, address=@address, suburb=@suburb, postcode=@postcode", con);

            SqlCommand insert = new SqlCommand(" INSERT INTO _CompanyDetails (companyRep, phoneNumber, address, suburb, postcode, companyId)" +
                                    "VALUES (@companyRep, @phoneNumber, @address, @suburb, @postcode, @companyId)", con);


            

            //checks the database to see if user exists
            con.Open();
            rdr = cmd.ExecuteReader();
            int dataCount = 0;

            while (rdr.Read())
            {
                dataCount++;
            }
            con.Close();

            //if user exists update the database from user input
            if (dataCount > 0)
            {
                modify.Parameters.Add("@companyRep", System.Data.SqlDbType.VarChar).Value = member.CompanyRep;
                modify.Parameters.Add("@phoneNumber", System.Data.SqlDbType.VarChar).Value = member.PhoneNumber;
                modify.Parameters.Add("@address", System.Data.SqlDbType.VarChar).Value = member.Address;
                modify.Parameters.Add("@suburb", System.Data.SqlDbType.VarChar).Value = member.Suburb;
                modify.Parameters.Add("@postcode", System.Data.SqlDbType.VarChar).Value = member.Postcode;


                con.Open();
                modify.ExecuteNonQuery();
                con.Close();
                //lblProStatus.Text = "Details succesfully updated.";
                lblModalTitle.Text = "CONGRATULATIONS!";
                lblModalBody.Text = "Details succesfully updated.";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }

            //if user doesnt exist adds the user input to database
            else
            {
                insert.Parameters.Add("@companyRep", System.Data.SqlDbType.VarChar).Value = member.CompanyRep;
                insert.Parameters.Add("@phoneNumber", System.Data.SqlDbType.VarChar).Value = member.PhoneNumber;
                insert.Parameters.Add("@address", System.Data.SqlDbType.VarChar).Value = member.Address;
                insert.Parameters.Add("@suburb", System.Data.SqlDbType.VarChar).Value = member.Suburb;
                insert.Parameters.Add("@postcode", System.Data.SqlDbType.VarChar).Value = member.Postcode;
                insert.Parameters.Add("@companyId", System.Data.SqlDbType.VarChar).Value = Convert.ToInt32(Session["fmID"]);

                

                con.Open();
                insert.ExecuteNonQuery();
                
                con.Close();

                //lblProStatus.Text = "Details succesfully updated.";
                lblModalTitle.Text = "CONGRATULATIONS!";
                lblModalBody.Text = "Details succesfully updated.";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();

            }
        }
    }
}