<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusDashboard.aspx.cs" Inherits="FollowMe302.BusDashboard" %>

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
               <a href="BusDashboard.aspx" role="button" id="btnBusDashboard" class="btn btn-lg btn-block active fBtn">Dashboard</a>
               <br />
               <a href="#" role="button" id="btnGetClientProfile" class="btn btn-lg btn-block fBtn">Get Client Profile</a>              
               <br />
               <a href="#" role="button" id="btnSendClientNotif" class="btn btn-lg btn-block fBtn">Send Client Notification</a>  
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
                   <div class="panel-heading">Dashboard</div>
                   <div class="panel-body">
                       <asp:Label ID="lblNotStatus" runat="server" Text=" ">No notifications</asp:Label>
                   </div>
               </div>
              </div>                    
           </div>
       </div>         
</body>
</html>
