<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCompanyDetails.aspx.cs" Inherits="FollowMe302.EditCompanyDetails" %>

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
               <a href="BusDashboard.aspx" role="button" id="btnBusDashboard" class="btn btn-lg btn-block fBtn">Dashboard</a>
               <br />
               <a href="GetClientDetails.aspx" role="button" id="btnGetClientProfile" class="btn btn-lg btn-block fBtn">Get Client Profile</a>              
               <br />
               <a href="SendClientNotification.aspx" role="button" id="btnSendClientNotif" class="btn btn-lg btn-block fBtn">Send Client Notification</a>  
               <br />
               <a href="EditCompanyDetails.aspx" role="button" id="btnEditCompanyDetails" class="btn btn-lg btn-block active fBtn">Edit Company Details</a> 
               <br />
               <a href="ViewCompanyDetails.aspx" role="button" id="btnViewCompanyDetails" class="btn btn-lg btn-block fBtn">View Company Details</a> 
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
                       <p id="pHeading">Edit Company Details</p>
                       <p id="pSubHeading">Add/Update your company's details.</p>
                   </div>
                   <div class="panel-body">
                       <form id="editForm" runat="server">
                           <div class="row">
                               <div class="col-md-6">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtEditRepName" runat="server" placeholder="Representative Name" CssClass="form-control"></asp:TextBox>                                   
                                   </div>
                               </div>
                               <div class="col-md-6">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtEditPhoneNumber" runat="server" placeholder="Phone Number" CssClass="form-control"></asp:TextBox>                                 
                                   </div>
                               </div> 
                           </div>
                           
                           <div class="row">
                               <div class="col-md-6">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtEditAddress" runat="server" placeholder="Address" CssClass="form-control"></asp:TextBox>                                   
                                   </div>
                               </div>
                               
                               <div class="col-md-6">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtEditSuburb" runat="server" placeholder="Suburb" CssClass="form-control"></asp:TextBox> 
                                   </div>
                               </div>
                           </div>

                           <div class="row">
                               <div class="col-md-6">
                                   <div class="form-group">
                                       <asp:TextBox ID="txtEditPostcode" runat="server" placeholder="Postcode" CssClass="form-control"></asp:TextBox>                                   
                                   </div>
                               </div>                                                              
                           </div>                           

                           <div class="row">
                               <div class="col-md-12">
                                   <asp:Button ID="btnEditCoDetails" runat="server" Text="Add/Update Details" OnClick="btnEditCoDetails_Click" CssClass="btn pull-right fBtn" />
                               </div>                               
                           </div>

                           <asp:ScriptManager ID="asm" runat="server" />
                           <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                               <div class="modal-dialog">
                                   <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                       <ContentTemplate>
                                           <div class="modal-content">
                                               <div class="modal-header">
                                                   <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                   <h4 class="modal-title"><asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                                               </div>
                                               <div class="modal-body">
                                                   <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                                               </div>
                                               <div class="modal-footer">
                                                   <%--<asp:Button ID="btnClose" runat="server" CssClass="btn btn-info fBtn" Text="Close" OnClick="btnClose_Click" />--%>
                                                   <button id="btnColse" class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                                               </div>
                                           </div>
                                       </ContentTemplate>
                                   </asp:UpdatePanel>
                               </div>
                           </div>
                           
                       </form>
                       
                       <div class="clearfix">
                           <asp:Label ID="lblEditCoStatus" runat="server" Text=" "></asp:Label>
                       </div>
                   </div>
               </div>
              </div>                    
           </div>
       </div>         
</body>
</html>
