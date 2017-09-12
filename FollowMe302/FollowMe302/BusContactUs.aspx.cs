using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FollowMe302.Csharp;
using System.Data.SqlClient;
using PostmarkDotNet;
using PostmarkDotNet.Model;
using System.IO;
using System.Threading.Tasks;
using PostmarkDotNet.Legacy;
using PostmarkDotNet.Webhooks;

namespace FollowMe302
{
    public partial class BusContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string compUserName = Session["name"].ToString();
            string compFollowId = Session["fmID"].ToString();

            //adds the session variable
            lblSession.Text = "Hello " + compUserName;
        }

        protected void btnContactSend_Click(object sender, EventArgs e)
        {

        }
    }
}