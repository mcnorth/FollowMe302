﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusDashboard.aspx.cs" Inherits="FollowMe302.BusDashboard" %>

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
               <a href="EditCompanyDetails.aspx" role="button" id="btnEditCompanyDetails" class="btn btn-lg btn-block fBtn">Edit Company Details</a> 
               <br />
               <a href="ViewCompanyDetails.aspx" role="button" id="btnViewCompanyDetails" class="btn btn-lg btn-block fBtn">View Company Details</a> 
               <br />
               <a href="Login.aspx" role="button" id="btnLogout" class="btn btn-lg btn-block fBtn">Log Out</a> 
               <div id="footer">
                   
               </div>
           </div>
           <div id="mainContent" class="col-sm-10">
               <div class="row">
                   <div id="top-header">
                       <div class="col-sm-3">
                           <asp:Label ID="lblSession" runat="server" Text="">Hello</asp:Label>
                       </div>
                       <div class="col-sm-3">
                           <a href="BusTermsConditions.aspx" id="fContentLeft">Terms & Conditions</a>
                           <a href="BusContactUs.aspx" id="fContentRight">Contact us</a>
                       </div>
                       <div class="col-sm-6">
                       
                       </div>
                   </div>
               </div>
               
               <hr />
               <div class="panel panel-default">
                   <div class="panel-heading">Dashboard</div>
                   <div class="panel-body">
                       <form id="editForm" runat="server">
                       <asp:Panel ID="notifPanel" runat="server">
                           <asp:Label ID="lblNotStatus" runat="server" Text=" "></asp:Label>
                       </asp:Panel>
                           </form>
                   </div>
               </div>
              </div>                    
           </div>
       </div>         
</body>
</html>
