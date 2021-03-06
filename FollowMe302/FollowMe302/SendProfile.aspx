﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendProfile.aspx.cs" Inherits="FollowMe302.SendProfile" %>
<%@ Register Assembly="ASP.Web.UI.PopupControl" Namespace="ASP.Web.UI.PopupControl" TagPrefix="ASPP" %>

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
                                   <br />
                                   <asp:DropDownList ID="ddlSendPro" runat="server" AppendDataBoundItems="false" CssClass="btn dropdown-toggle fBtn">
                                       <asp:ListItem Text= " ">Choose...</asp:ListItem>
                                   </asp:DropDownList>
                               
                               </div>                              
                           </div>
                           <br />
                           <div class="row">
                               <div class="col-md-6">
                                   <div class="form-group">
                                       <label for="txtSendFirstName">First Name</label>
                                       <asp:TextBox ID="txtSendFirstName" runat="server" CssClass="form-control"></asp:TextBox>                                   
                                   </div>
                               </div>
                               
                               <div class="col-md-6">
                                   <div class="form-group">
                                       <label for="txtSendLastName">Last Name</label>
                                       <asp:TextBox ID="txtSendLastName" runat="server" CssClass="form-control"></asp:TextBox> 
                                   </div>
                               </div>
                           </div>

                           <div class="row">
                               <div class="col-md-6">
                                   <div class="form-group">
                                       <label for="txtSendFollowId">Follow Me ID</label>
                                       <asp:TextBox ID="txtSendFollowId" runat="server" placeholder="Follow Me ID" CssClass="form-control"></asp:TextBox>                                   
                                   </div>
                               </div>
                               
                               <div class="col-md-6">
                                   <div class="form-group">
                                       <label for="txtSendEmail">Email</label>
                                       <asp:TextBox ID="txtSendEmail" runat="server" CssClass="form-control"></asp:TextBox> 
                                   </div>
                               </div>
                           </div>

                           <div class="row">
                               <div class="col-md-4">
                                   <div class="form-group">
                                       <label for="txtSendHouseNo">House Number</label>
                                       <asp:TextBox ID="txtSendHouseNo" runat="server" CssClass="form-control"></asp:TextBox>                                   
                                   </div>
                               </div>
                               
                               <div class="col-md-4">
                                   <div class="form-group">
                                       <label for="txtSendStreet">Street Name</label>
                                       <asp:TextBox ID="txtSendStreet" runat="server" CssClass="form-control"></asp:TextBox> 
                                   </div>
                               </div>

                               <div class="col-md-4">
                                   <div class="form-group">
                                       <label for="txtSendSuburb">Suburb</label>
                                       <asp:TextBox ID="txtSendSuburb" runat="server" CssClass="form-control"></asp:TextBox> 
                                   </div>
                               </div>
                           </div>

                           <div class="row">
                               <div class="col-md-4">
                                   <div class="form-group">
                                       <label for="txtSendState">State</label>
                                       <asp:TextBox ID="txtSendState" runat="server" CssClass="form-control"></asp:TextBox>                                   
                                   </div>
                               </div>
                               
                               <div class="col-md-4">
                                   <div class="form-group">
                                       <label for="txtSendCountry">Country</label>
                                       <asp:TextBox ID="txtSendCountry" runat="server" CssClass="form-control"></asp:TextBox> 
                                   </div>
                               </div>

                               <div class="col-md-4">
                                   <div class="form-group">
                                       <label for="txtSendPostcode">Postcode</label>
                                       <asp:TextBox ID="txtSendPostcode" runat="server" CssClass="form-control"></asp:TextBox> 
                                   </div>
                               </div>
                           </div>
                           <div class="row">
                               <div class="col-md-12">
                                   <asp:Button ID="btnSendMyProfile" runat="server" Text="Send Profile" CssClass="btn pull-right fBtn" OnClick="btnSendMyProfile_Click" />
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
                                                   <asp:Button ID="btnClose" runat="server" CssClass="btn btn-info fBtn" Text="Close" OnClick="btnClose_Click" />
                                                   <%--<button id="btnColse" class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>--%>
                                               </div>
                                           </div>
                                       </ContentTemplate>
                                   </asp:UpdatePanel>
                               </div>
                           </div>

                           <div class="modal fade" id="theModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                               <div class="modal-dialog">
                                   <asp:UpdatePanel ID="theupModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                       <ContentTemplate>
                                           <div class="modal-content">
                                               <div class="modal-header">
                                                   <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                   <h4 class="modal-title"><asp:Label ID="lblmodeltitle2" runat="server" Text=""></asp:Label></h4>
                                               </div>
                                               <div class="modal-body">
                                                   <asp:Label ID="lblmodelbody2" runat="server" Text=""></asp:Label>
                                               </div>
                                               <div class="modal-footer">
                                                   <asp:Button ID="btn2Close" runat="server" CssClass="btn btn-info fBtn" Text="Close" OnClick="btn2Close_Click" />
                                                   <%--<button id="btnColse" class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>--%>
                                               </div>
                                           </div>
                                       </ContentTemplate>
                                   </asp:UpdatePanel>
                               </div>
                           </div>
                       </form>
                       


                       <div class="clearfix">
                           <asp:Label ID="lblSendStatus" runat="server" Text=" "></asp:Label>
                       </div>                       
                   </div>
               </div>
              </div>     

           </div>
       </div> 
</body>
</html>
