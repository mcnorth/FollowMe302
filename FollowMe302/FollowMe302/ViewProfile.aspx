<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewProfile.aspx.cs" Inherits="FollowMe302.ViewProfile" %>

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
                       <asp:Label ID="lblViewStatus" runat="server" Text=""></asp:Label>
                   </div>

                   <div class="panel-body">
                       <form id="editForm" runat="server">
                           <div class="row">
                               <div class="col-md-6">
                                   <div class="form-group">
                                       <label for="txtViewFirstName">First Name</label>
                                       <asp:TextBox ID="txtViewFirstName" runat="server" CssClass="form-control"></asp:TextBox>                                   
                                   </div>
                               </div>
                               
                               <div class="col-md-6">
                                   <div class="form-group">
                                       <label for="txtViewLastName">Last Name</label>
                                       <asp:TextBox ID="txtViewLastName" runat="server" CssClass="form-control"></asp:TextBox> 
                                   </div>
                               </div>
                           </div>

                           <div class="row">                                                             
                               <div class="col-md-6">
                                   <div class="form-group">
                                       <label for="txtViewEmail">Email</label>
                                       <asp:TextBox ID="txtViewEmail" runat="server" CssClass="form-control"></asp:TextBox> 
                                   </div>
                               </div>

                               <div class="col-md-6">
                                   <div class="form-group">
                                       <label for="txtViewPhoneNumber">Phone Number</label>
                                       <asp:TextBox ID="txtViewPhoneNumber" runat="server" CssClass="form-control"></asp:TextBox>                                   
                                   </div>
                               </div>
                           </div>

                           <div class="row">
                               <div class="col-md-4">
                                   <div class="form-group">
                                       <label for="txtViewHouseNo">House Number</label>
                                       <asp:TextBox ID="txtViewHouseNo" runat="server" CssClass="form-control"></asp:TextBox>                                   
                                   </div>
                               </div>
                               
                               <div class="col-md-4">
                                   <div class="form-group">
                                       <label for="txtViewStreet">Street Name</label>
                                       <asp:TextBox ID="txtViewStreet" runat="server" CssClass="form-control"></asp:TextBox> 
                                   </div>
                               </div>

                               <div class="col-md-4">
                                   <div class="form-group">
                                       <label for="txtViewSuburb">Suburb</label>
                                       <asp:TextBox ID="txtViewSuburb" runat="server" CssClass="form-control"></asp:TextBox> 
                                   </div>
                               </div>
                           </div>

                           <div class="row">
                               <div class="col-md-4">
                                   <div class="form-group">
                                       <label for="txtViewState">State</label>
                                       <asp:TextBox ID="txtViewState" runat="server" CssClass="form-control"></asp:TextBox>                                   
                                   </div>
                               </div>
                               
                               <div class="col-md-4">
                                   <div class="form-group">
                                       <label for="txtViewCountry">Country</label>
                                       <asp:TextBox ID="txtViewCountry" runat="server" CssClass="form-control"></asp:TextBox> 
                                   </div>
                               </div>

                               <div class="col-md-4">
                                   <div class="form-group">
                                       <label for="txtViewPostcode">Postcode</label>
                                       <asp:TextBox ID="txtViewPostcode" runat="server" CssClass="form-control"></asp:TextBox> 
                                   </div>
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
                   </div>
               </div>
              </div>     

           </div>
       </div> 
</body>
</html>
