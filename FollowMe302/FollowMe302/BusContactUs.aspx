<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusContactUs.aspx.cs" Inherits="FollowMe302.BusContactUs" %>

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
                   <div class="panel-heading">
                       <p id="pHeading">Edit Company Details</p>
                       <p id="pSubHeading">We are happy to answer any questions. Just send us a message in the form below.</p>
                   </div>

                   <div class="panel-body">
                       <form id="editForm" runat="server">
                           <div class="row">
                               <div class="col-md-12">
                                   <div class="form-group">
                                       <label for="txtContactName">Your Name (required)</label>
                                       <asp:TextBox ID="txtContactName" runat="server" CssClass="form-control"></asp:TextBox>                                   
                                   </div>
                               </div>                              
                           </div>
                           
                           <div class="row">
                               <div class="col-md-12">
                                   <div class="form-group">
                                       <label for="txtContactEmail">Your Email (required)</label>
                                       <asp:TextBox ID="txtContactEmail" runat="server" CssClass="form-control"></asp:TextBox>                                 
                                   </div>
                               </div> 
                           </div>

                           <div class="row">
                               <div class="col-md-12">
                                   <div class="form-group">
                                       <label for="txtContactSub">Subject</label>
                                       <asp:TextBox ID="txtContactSub" runat="server" CssClass="form-control"></asp:TextBox>                                 
                                   </div>
                               </div> 
                           </div>
                           
                           <div class="row">
                               <div class="col-md-12">
                                   <div class="form-group">
                                       <label for="txtContactMsg">Your Message</label>
                                       <asp:TextBox ID="txtContactMsg" runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control"></asp:TextBox>                                 
                                   </div>
                               </div> 
                           </div>  

                           <div class="row">
                               <div class="col-md-12">
                                   <asp:Button ID="btnContactSend" runat="server" Text="Send" OnClick="btnContactSend_Click" CssClass="btn pull-right fBtn" />
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
