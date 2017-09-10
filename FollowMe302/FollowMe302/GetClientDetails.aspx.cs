﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FollowMe302.Csharp;
using System.Data.SqlClient;

namespace FollowMe302
{
    public partial class GetClientDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string compUserName = Session["name"].ToString();
            string compFollowId = Session["fmID"].ToString();

            //adds the session variable
            lblSession.Text = "Hello " + compUserName;
        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            string clientId = txtClientId.Text;
            //sql connections and query
            SqlConnection con = new SqlConnection(@"Data Source=182.50.133.109; Database=FollowMe; Integrated Security=False; User ID=kellie; Password=rQp45a1^; Connect Timeout=15; Encrypt=False; Packet Size=4096");

            //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|FollowMeDatabase.mdf; Integrated Security=True");

            SqlDataReader rdr = null;
            SqlCommand cmd = new SqlCommand("SELECT * FROM [_UserDetails] WHERE [followMeId] = '" + clientId + "'", con);

            //opens connection reads the database as per the query
            //counts how many rows and adds to the variable datacount
            con.Open();
            rdr = cmd.ExecuteReader();
            int dataCount = 0;
            while (rdr.Read())
            {
                dataCount++;
            }
            con.Close();

            //if one row found reads the database annd adds the records to the specific text boxes
            if (dataCount > 0)
            {
                con.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtGetFirstName.Text = (string)rdr["firstName"];
                    txtGetLastName.Text = (string)rdr["lastName"];
                    txtGetHouseNo.Text = (string)rdr["houseNumber"];
                    txtGetStreet.Text = (string)rdr["streetName"];
                    txtGetSuburb.Text = (string)rdr["suburb"];
                    txtGetState.Text = (string)rdr["stat"];
                    txtGetCountry.Text = (string)rdr["country"];
                    txtGetPostcode.Text = (string)rdr["postcode"];
                    txtGetFollowId.Text = Convert.ToString(rdr["followMeId"]);
                    txtGetEmail.Text = (string)rdr["email"];

                }

            }

            //if no records found leaves the text boxes blank
            else
            {
                txtGetFirstName.Text = "";
                txtGetLastName.Text = "";
                txtGetHouseNo.Text = "";
                txtGetStreet.Text = "";
                txtGetSuburb.Text = "";
                txtGetState.Text = "";
                txtGetCountry.Text = "";
                txtGetPostcode.Text = "";
                txtGetFollowId.Text = "";
                txtGetEmail.Text = "";

                lblModalTitle.Text = "ERROR!";
                lblModalBody.Text = "User does not exist.";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }

            con.Close();
        }
    }
}