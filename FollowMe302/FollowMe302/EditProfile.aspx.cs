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
    public partial class EditProfile : System.Web.UI.Page
    {
        /// <summary>
        /// Page load happens when the page is loaded
        /// This is where the session variables are added to string variables
        /// It uses an asp label to attach some text with the session variable
        /// </summary> 
        protected void Page_Load(object sender, EventArgs e)
        {
            string clientUserName = Session["name"].ToString();
            string clientFollowId = Session["fmID"].ToString();

            //adds the session variable
            lblSession.Text = "Hello " + clientUserName;
        }

        /// <summary>
        /// btnEditCoDetails_Click is the event from the update button
        /// This is where the app takes the user input from teh textboxes
        /// It then checks the database table [user details] for existing records
        /// If record is found it will modify the existing data
        /// If records are not found it will update the table
        /// </summary> 
        protected void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["fmID"]);
            //adds user input from the text boxes to an object
            MemberEntity member = new MemberEntity();
            member.FirstName = txtEditFirstName.Text;
            member.LastName = txtEditLastName.Text;

            member.Email = txtEditEmail.Text;
            member.HouseNumber = txtEditHouseNo.Text;
            member.StreetName = txtEditStreet.Text;
            member.Suburb = txtEditSuburb.Text;
            member.State = txtEditState.Text;
            member.Country = txtEditCountry.Text;
            member.Postcode = txtEditPostcode.Text;
            member.PhoneNumber = txtEditPhoneNumber.Text;

            //creates connection and queries
            SqlConnection con = new SqlConnection(@"Data Source=182.50.133.109; Database=FollowMe; Integrated Security=False; User ID=kellie; Password=rQp45a1^; Connect Timeout=15; Encrypt=False; Packet Size=4096");

            //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|FollowMeDatabase.mdf; Integrated Security=True");

            SqlDataReader rdr = null;

            SqlCommand cmd = new SqlCommand("SELECT * FROM [_UserDetails] WHERE [followMeId] = '" + id + "'", con);

            SqlCommand modify = new SqlCommand("UPDATE _UserDetails SET houseNumber=@houseNumber, streetName=@streetName, suburb=@suburb, stat=@stat, country=@country, postcode=@postcode,  firstName=@firstName, lastName=@lastName, phoneNumber=@phoneNumber", con);

            SqlCommand modifyUser = new SqlCommand("UPDATE _User SET email=@email WHERE followMeId = '" + id + "'", con);

            SqlCommand insert = new SqlCommand(" INSERT INTO _UserDetails (houseNumber, streetName, suburb, stat, country, postcode, followMeId, firstName, lastName, phoneNumber)" +
                                    "VALUES (@houseNumber, @streetName, @suburb, @stat, @country, @postcode, @followMeId, @firstName, @lastName, @phoneNumber)", con);
           

            //checks the database to see if user exists
            con.Open();
            rdr = cmd.ExecuteReader();
            int dataCount = 0;

            while (rdr.Read())
            {
                dataCount++;
            }
            con.Close();

            //if user info exists update the database from user input
            if (dataCount > 0)
            {
                modify.Parameters.Add("@houseNumber", System.Data.SqlDbType.VarChar).Value = member.HouseNumber;
                modify.Parameters.Add("@streetName", System.Data.SqlDbType.VarChar).Value = member.StreetName;
                modify.Parameters.Add("@suburb", System.Data.SqlDbType.VarChar).Value = member.Suburb;
                modify.Parameters.Add("@stat", System.Data.SqlDbType.VarChar).Value = member.State;
                modify.Parameters.Add("@country", System.Data.SqlDbType.VarChar).Value = member.Country;
                modify.Parameters.Add("@postcode", System.Data.SqlDbType.VarChar).Value = member.Postcode;
                modify.Parameters.Add("@firstName", System.Data.SqlDbType.VarChar).Value = member.FirstName;
                modify.Parameters.Add("@lastName", System.Data.SqlDbType.VarChar).Value = member.LastName;
                modify.Parameters.Add("@phoneNumber", System.Data.SqlDbType.VarChar).Value = member.PhoneNumber;

                modifyUser.Parameters.Add("@email", System.Data.SqlDbType.VarChar).Value = member.Email;

                con.Open();
                modify.ExecuteNonQuery();
                modifyUser.ExecuteNonQuery();
                con.Close();

                //lblEditStatus.Text = "Details succesfully updated.";
                lblModalTitle.Text = "CONGRATULATIONS!";
                lblModalBody.Text = "Details successfully updated.";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }

            //if user info doesnt exist adds the user input to database
            else
            {
                insert.Parameters.Add("@houseNumber", System.Data.SqlDbType.VarChar).Value = member.HouseNumber;
                insert.Parameters.Add("@streetName", System.Data.SqlDbType.VarChar).Value = member.StreetName;
                insert.Parameters.Add("@suburb", System.Data.SqlDbType.VarChar).Value = member.Suburb;
                insert.Parameters.Add("@stat", System.Data.SqlDbType.VarChar).Value = member.State;
                insert.Parameters.Add("@country", System.Data.SqlDbType.VarChar).Value = member.Country;
                insert.Parameters.Add("@postcode", System.Data.SqlDbType.VarChar).Value = member.Postcode;
                insert.Parameters.Add("@followMeId", System.Data.SqlDbType.VarChar).Value = Session["fmID"];
                insert.Parameters.Add("@firstName", System.Data.SqlDbType.VarChar).Value = member.FirstName;
                insert.Parameters.Add("@lastName", System.Data.SqlDbType.VarChar).Value = member.LastName;
                insert.Parameters.Add("@phoneNumber", System.Data.SqlDbType.VarChar).Value = member.PhoneNumber;


                con.Open();
                insert.ExecuteNonQuery();
                con.Close();



                //lblEditStatus.Text = "Details succesfully updated.";
                lblModalTitle.Text = "CONGRATULATIONS!";
                lblModalBody.Text = "Details successfully added.";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();

            }
        }
    }
}