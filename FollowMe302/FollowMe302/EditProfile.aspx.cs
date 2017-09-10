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
    public partial class EditProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string clientUserName = Session["name"].ToString();
            string clientFollowId = Session["fmID"].ToString();

            //adds the session variable
            lblSession.Text = "Hello " + clientUserName;
        }

        protected void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            //adds user input from the text boxes to an object
            MemberEntity member = new MemberEntity();
            member.FirstName = txtEditFirstName.Text;
            member.LastName = txtEditLastName.Text;
            member.UserName = txtEditUsername.Text;
            member.Email = txtEditEmail.Text;
            member.HouseNumber = txtEditHouseNo.Text;
            member.StreetName = txtEditStreet.Text;
            member.Suburb = txtEditSuburb.Text;
            member.State = txtEditState.Text;
            member.Country = txtEditCountry.Text;
            member.Postcode = txtEditPostcode.Text;

            //creates connection and queries
            SqlConnection con = new SqlConnection(@"Data Source=182.50.133.109; Database=FollowMe; Integrated Security=False; User ID=kellie; Password=rQp45a1^; Connect Timeout=15; Encrypt=False; Packet Size=4096");

            //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|FollowMeDatabase.mdf; Integrated Security=True");

            SqlDataReader rdr = null;

            SqlCommand cmd = new SqlCommand("SELECT * FROM [_UserDetails] WHERE [userName] = '" + member.UserName + "'", con);

            SqlCommand modify = new SqlCommand("UPDATE _UserDetails SET houseNumber=@houseNumber, streetName=@streetName, suburb=@suburb, stat=@stat, country=@country, postcode=@postcode, userName=@userName, firstName=@firstName, lastName=@lastName, email=@email", con);

            SqlCommand insert = new SqlCommand(" INSERT INTO _UserDetails (houseNumber, streetName, suburb, stat, country, postcode, email, userName, firstName, lastName)" +
                                    "VALUES (@houseNumber, @streetName, @suburb, @stat, @country, @postcode, @email, @userName, @firstName, @lastName)", con);


            SqlCommand insertId = new SqlCommand("UPDATE _UserDetails SET followMeId = (SELECT followMeId FROM _User WHERE userName = @userName) WHERE userName=@userName", con);

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
                modify.Parameters.Add("@userName", System.Data.SqlDbType.VarChar).Value = member.UserName;
                modify.Parameters.Add("@firstName", System.Data.SqlDbType.VarChar).Value = member.FirstName;
                modify.Parameters.Add("@lastName", System.Data.SqlDbType.VarChar).Value = member.LastName;
                modify.Parameters.Add("@email", System.Data.SqlDbType.VarChar).Value = member.Email;

                con.Open();
                modify.ExecuteNonQuery();
                con.Close();
                lblEditStatus.Text = "Details succesfully updated.";
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
                insert.Parameters.Add("@userName", System.Data.SqlDbType.VarChar).Value = member.UserName;
                insert.Parameters.Add("@firstName", System.Data.SqlDbType.VarChar).Value = member.FirstName;
                insert.Parameters.Add("@lastName", System.Data.SqlDbType.VarChar).Value = member.LastName;
                insert.Parameters.Add("@email", System.Data.SqlDbType.VarChar).Value = member.Email;

                insertId.Parameters.Add("@userName", System.Data.SqlDbType.VarChar).Value = member.UserName;

                con.Open();
                insert.ExecuteNonQuery();
                insertId.ExecuteNonQuery();
                con.Close();



                lblEditStatus.Text = "Details succesfully updated.";

            }
        }
    }
}