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
    public partial class ViewCompanyDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string compUserName = Session["name"].ToString();
            string compFollowId = Session["fmID"].ToString();

            //adds the session variable
            lblSession.Text = "Hello " + compUserName;

            //sql connections and query
            SqlConnection con = new SqlConnection(@"Data Source=182.50.133.109; Database=FollowMe; Integrated Security=False; User ID=kellie; Password=rQp45a1^; Connect Timeout=15; Encrypt=False; Packet Size=4096");

            //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|FollowMeDatabase.mdf; Integrated Security=True");

            SqlDataReader rdr = null;
            SqlDataReader rdrCo = null;
            SqlCommand cmd = new SqlCommand("SELECT * FROM [_CompanyDetails] WHERE [companyId] = (SELECT companyId FROM _Company WHERE companyName = '" + compUserName + "')", con);

            SqlCommand cmdCo = new SqlCommand("SELECT * FROM [_Company] WHERE [companyName] = '" + compUserName + "'", con);

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


                    txtViewCompanyRep.Text = (string)rdr["companyRep"];
                    txtViewCompanyPhone.Text = (string)rdr["phoneNumber"];
                    txtViewCompanyAddress.Text = (string)rdr["address"];
                    txtViewCompanySuburb.Text = (string)rdr["suburb"];
                    txtViewCompanyPostcode.Text = (string)rdr["postcode"];

                }

            }

            //if no records found leaves the text boxes blank
            else
            {
                txtViewCompanyRep.Text = "";
                txtViewCompanyPhone.Text = "";
                txtViewCompanyAddress.Text = "";
                txtViewCompanySuburb.Text = "";
                txtViewCompanyPostcode.Text = "";

                lblModalTitle.Text = "ERROR!";
                lblModalBody.Text = "Company details need to be added.";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }

            con.Close();

            con.Open();
            rdrCo = cmdCo.ExecuteReader();
            int dataCounter = 0;
            while (rdrCo.Read())
            {
                dataCounter++;
            }
            con.Close();

            //if one row found reads the database annd adds the records to the specific text boxes
            if (dataCounter > 0)
            {
                con.Open();
                rdrCo = cmdCo.ExecuteReader();
                while (rdrCo.Read())
                {


                    txtViewCompanyName.Text = (string)rdrCo["companyName"];
                    txtViewCompanyEmail.Text = (string)rdrCo["email"];
                    txtViewCompanyId.Text = Convert.ToString(rdrCo["companyId"]);

                }

            }

            //if no records found leaves the text boxes blank
            else
            {
                txtViewCompanyName.Text = "";
                txtViewCompanyEmail.Text = "";
                txtViewCompanyId.Text = "";

                

            }

            con.Close();
        }
    }
}