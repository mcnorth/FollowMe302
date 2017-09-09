<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCompanyDetails.aspx.cs" Inherits="FollowMe302.ViewCompanyDetails" %>

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
               <a href="SendClientNotification.aspx" role="button" id="btnSendClientNotif" class="btn btn-lg btn-block fBtn">Send Client Notification</a>  
               <br />
               <a href="EditCompanyDetails.aspx" role="button" id="btnEditCompanyDetails" class="btn btn-lg btn-block fBtn">Edit Company Details</a> 
               <br />
               <a href="ViewCompanyDetails.aspx" role="button" id="btnViewCompanyDetails" class="btn btn-lg btn-block active fBtn">View Company Details</a> 
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
                       <p id="pHeading">View Company Details</p>
                       <p id="pSubHeading">View your current company's details.</p>
                   </div>
                   <div class="panel-body">
                       <form id="editForm" runat="server">
                           <div class="row">
                               <div class="col-md-6">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtViewCompanyName" runat="server" placeholder="Company Name" CssClass="form-control"></asp:TextBox>                                   
                                   </div>
                               </div>
                               <div class="col-md-6">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtViewCompanyEmail" runat="server" placeholder="Company Email" CssClass="form-control"></asp:TextBox>                                 
                                   </div>
                               </div> 
                           </div>
                           
                           <div class="row">
                               <div class="col-md-6">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtViewCompanyRep" runat="server" placeholder="Company Representative" CssClass="form-control"></asp:TextBox>                                   
                                   </div>
                               </div>
                               
                               <div class="col-md-6">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtViewCompanyPhone" runat="server" placeholder="Phone Number" CssClass="form-control"></asp:TextBox> 
                                   </div>
                               </div>
                           </div>

                           <div class="row">
                               <div class="col-md-6">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtViewCompanyAddress" runat="server" placeholder="Address" CssClass="form-control"></asp:TextBox>                                   
                                   </div>
                               </div> 
                               <div class="col-md-6">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtViewCompanySuburb" runat="server" placeholder="Suburb" CssClass="form-control"></asp:TextBox>                                   
                                   </div>
                               </div>
                           </div> 
                           
                           <div class="row">
                               <div class="col-md-6">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtViewCompanyPostcode" runat="server" placeholder="Postcode" CssClass="form-control"></asp:TextBox>                                   
                                   </div>
                               </div> 
                               <div class="col-md-6">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtViewCompanyId" runat="server" placeholder="Follow Me Id" CssClass="form-control"></asp:TextBox>                                   
                                   </div>
                               </div>
                           </div>                                                        
                       </form>                       
                       <div class="clearfix">
                           <asp:Label ID="lblEditCoStatus" runat="server" Text=" ">No updates</asp:Label>
                       </div>
                   </div>
               </div>
              </div>                    
           </div>
       </div>         
</body>
</html>
