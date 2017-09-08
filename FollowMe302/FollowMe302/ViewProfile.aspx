﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewProfile.aspx.cs" Inherits="FollowMe302.ViewProfile" %>

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
               <a href="ClientDashboard.aspx" role="button" id="btnDashboard" class="btn btn-lg btn-block fBtn">Dashboard</a>
               <br />
               <a href="EditProfile.aspx" role="button" id="btnEditProfile" class="btn btn-lg btn-block  fBtn">Edit Profile</a>              
               <br />
               <a href="ViewProfile.aspx" role="button" id="btnViewProfile" class="btn btn-lg btn-block active fBtn">View Profile</a>  
               <br />
               <a href="SendProfile.aspx" role="button" id="btnSendProfile" class="btn btn-lg btn-block fBtn">Send Profile</a> 
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
                       <p id="pHeading">View Profile</p>
                       <p id="pSubHeading">View your completed profile</p>
                   </div>

                   <div class="panel-body">
                       <form id="editForm" runat="server">
                           <div class="row">
                               <div class="col-md-6">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtViewFirstName" runat="server" placeholder="First Name" CssClass="form-control"></asp:TextBox>                                   
                                   </div>
                               </div>
                               
                               <div class="col-md-6">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtViewLastName" runat="server" placeholder="Last Name" CssClass="form-control"></asp:TextBox> 
                                   </div>
                               </div>
                           </div>

                           <div class="row">
                               <div class="col-md-6">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtViewUsername" runat="server" placeholder="Username" CssClass="form-control"></asp:TextBox>                                   
                                   </div>
                               </div>
                               
                               <div class="col-md-6">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtViewEmail" runat="server" placeholder="Email" CssClass="form-control"></asp:TextBox> 
                                   </div>
                               </div>
                           </div>

                           <div class="row">
                               <div class="col-md-4">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtViewHouseNo" runat="server" placeholder="House Number" CssClass="form-control"></asp:TextBox>                                   
                                   </div>
                               </div>
                               
                               <div class="col-md-4">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtViewStreet" runat="server" placeholder="Street Name" CssClass="form-control"></asp:TextBox> 
                                   </div>
                               </div>

                               <div class="col-md-4">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtViewSuburb" runat="server" placeholder="Suburb" CssClass="form-control"></asp:TextBox> 
                                   </div>
                               </div>
                           </div>

                           <div class="row">
                               <div class="col-md-4">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtViewState" runat="server" placeholder="State" CssClass="form-control"></asp:TextBox>                                   
                                   </div>
                               </div>
                               
                               <div class="col-md-4">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtViewCountry" runat="server" placeholder="Country" CssClass="form-control"></asp:TextBox> 
                                   </div>
                               </div>

                               <div class="col-md-4">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtViewPostcode" runat="server" placeholder="Postcode" CssClass="form-control"></asp:TextBox> 
                                   </div>
                               </div>
                           </div>                          
                       </form>                                                                    
                   </div>
               </div>
              </div>     

           </div>
       </div> 
</body>
</html>