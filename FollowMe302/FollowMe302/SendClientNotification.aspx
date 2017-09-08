<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendClientNotification.aspx.cs" Inherits="FollowMe302.SendClientNotification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="css/main.css"/>
    <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css"/>
    <script src="scripts/bootstrap.min.js"></script>
    <script src="scripts/jquery-3.2.1.min.js"></script>
    
    <title></title>
</head>
<body style="background-color:#8cc63e">
    <div class="container-fluid">
       <div class="row">
           <div id="sideNav" class="col-sm-2">
               <img src="images/white-logo.png" class="img-responsive center" id="front-logo-white" />
               <hr />
               <a href="BusDashboard.aspx" role="button" id="btnBusDashboard" class="btn btn-lg btn-block fBtn">Dashboard</a>
               <br />
               <a href="GetClientDetails.aspx" role="button" id="btnGetClientProfile" class="btn btn-lg btn-block fBtn">Get Client Profile</a>              
               <br />
               <a href="SendClientNotification.aspx" role="button" id="btnSendClientNotif" class="btn btn-lg btn-block active fBtn">Send Client Notification</a>  
               <br />
               <a href="#" role="button" id="btnEditCompanyDetails" class="btn btn-lg btn-block fBtn">Edit Company Details</a> 
               <br />
               <a href="#" role="button" id="btnViewCompanyDetails" class="btn btn-lg btn-block fBtn">View Company Details</a> 
               <br />
               <a href="Login.aspx" role="button" id="btnLogout" class="btn btn-lg btn-block fBtn">Log Out</a> 
           </div>
           <div id="mainContent" class="col-sm-10">
               <div id="top-header">
                   <asp:Label ID="lblSession" runat="server" Text="">Hello</asp:Label>
               </div>
               <hr />
               <div class="panel panel-default">
                   <div class="panel-heading">
                       <p id="pHeading">Send Client Notification</p>
                       <p id="pSubHeading">Send an email and notification to the Follow Me client.</p>
                   </div>
                   <div class="panel-body">
                       <form id="editForm" runat="server">
                           <div class="row">
                               <div class="col-md-12">
                                   <div class="form-group">
                                       <textarea class="form-control" rows="5" id="comment"></textarea>                                  
                                   </div>
                               </div>
                              </div> 
                           <div class="row">
                               <div class="col-md-12">
                                   <asp:Button ID="btnSendMyProfile" runat="server" Text="Send Profile" CssClass="btn pull-right fBtn" />
                               </div>                               
                           </div>
                           
                       </form>
                       
                       <div class="clearfix">
                           <asp:Label ID="lblSendStatus" runat="server" Text=" ">No updates</asp:Label>
                       </div>
                   </div>
               </div>
              </div>                    
           </div>
       </div>         
</body>
</html>
