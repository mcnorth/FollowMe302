﻿using System;
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
            // Send an email asynchronously:
            var message = new PostmarkMessage()
            {
                To = "followmesit302@gmail.com",
                From = "kellie@kelliemcnaughton.com",
                TrackOpens = true,
                Subject = txtContactSub.Text,
                TextBody = "Plain Text Body",
                HtmlBody = txtContactMsg.Text,
                Tag = "New Year's Email Campaign",
                Headers = new HeaderCollection
                    {
                        { "X-CUSTOM-HEADER", "Header content"}
                    }
            };

            //var imageContent = File.ReadAllBytes("test.jpg");
            //message.AddAttachment(imageContent, "test.jpg", "image/jpg", "cid:embed_name.jpg");

            PostmarkClient client = new PostmarkClient("efc7197a-4c0d-4f4b-92f7-43c612ed74b1");
            PostmarkResponse response = client.SendMessage(message);


            if (response.Status != PostmarkStatus.Success)
            {
                lblModalTitle.Text = "ERROR!";
                lblModalBody.Text = "Message has not been sent. Please try again";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }
            else
            {
                lblModalTitle.Text = "CONGRATULATIONS!";
                lblModalBody.Text = "Message has been sent.";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }
        }
    }
}