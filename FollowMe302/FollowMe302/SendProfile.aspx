<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendProfile.aspx.cs" Inherits="FollowMe302.SendProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="css/main.css"/>
    <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css"/>
    <script src="scripts/javaScript.js"></script>
    <script src="scripts/jquery-3.2.1.min.js"></script>
    <script src="scripts/bootstrap.min.js"></script>
    
    
    
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
               <a href="ViewProfile.aspx" role="button" id="btnViewProfile" class="btn btn-lg btn-block fBtn">View Profile</a>  
               <br />
               <a href="SendProfile.aspx" role="button" id="btnSendProfile" class="btn btn-lg btn-block active fBtn">Send Profile</a> 
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
                       <p id="pHeading">Edit Profile</p>
                       <p id="pSubHeading">Complete your profile</p>
                   </div>

                   <div class="panel-body">
                       <form id="editForm" runat="server">
                           <div class="row">
                               <div class="col-md-12">
                                   <asp:Label runat="server" ID="lblSelBus">Select a business to send your profile to.</asp:Label>
                               <div class="dropdown">
                                   <button class="btn  dropdown-toggle fBtn" type="button" data-toggle="dropdown">Dropdown Example<span class="caret"></span></button>
                                   <ul class="dropdown-menu">
                                       <li><a href="#">HTML</a></li>
                                       <li><a href="#">CSS</a></li>
                                       <li><a href="#">JavaScript</a></li>
                                   </ul>
                               </div>
                               </div>                              
                           </div>
                           <br />
                           <div class="row">
                               <div class="col-md-6">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtSendFirstName" runat="server" placeholder="First Name" CssClass="form-control"></asp:TextBox>                                   
                                   </div>
                               </div>
                               
                               <div class="col-md-6">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtSendLastName" runat="server" placeholder="Last Name" CssClass="form-control"></asp:TextBox> 
                                   </div>
                               </div>
                           </div>

                           <div class="row">
                               <div class="col-md-6">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtSendFollowId" runat="server" placeholder="Follow Me ID" CssClass="form-control"></asp:TextBox>                                   
                                   </div>
                               </div>
                               
                               <div class="col-md-6">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtSendEmail" runat="server" placeholder="Email" CssClass="form-control"></asp:TextBox> 
                                   </div>
                               </div>
                           </div>

                           <div class="row">
                               <div class="col-md-4">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtSendHouseNo" runat="server" placeholder="House Number" CssClass="form-control"></asp:TextBox>                                   
                                   </div>
                               </div>
                               
                               <div class="col-md-4">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtSendStreet" runat="server" placeholder="Street Name" CssClass="form-control"></asp:TextBox> 
                                   </div>
                               </div>

                               <div class="col-md-4">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtSendSuburb" runat="server" placeholder="Suburb" CssClass="form-control"></asp:TextBox> 
                                   </div>
                               </div>
                           </div>

                           <div class="row">
                               <div class="col-md-4">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtSendState" runat="server" placeholder="State" CssClass="form-control"></asp:TextBox>                                   
                                   </div>
                               </div>
                               
                               <div class="col-md-4">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtSendCountry" runat="server" placeholder="Country" CssClass="form-control"></asp:TextBox> 
                                   </div>
                               </div>

                               <div class="col-md-4">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtSendPostcode" runat="server" placeholder="Postcode" CssClass="form-control"></asp:TextBox> 
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
