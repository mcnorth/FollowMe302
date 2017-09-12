<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientTermsConditions.aspx.cs" Inherits="FollowMe302.ClientTermsConditions" %>

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
               <a href="EditProfile.aspx" role="button" id="btnEditProfile" class="btn btn-lg btn-block fBtn">Edit Profile</a>              
               <br />
               <a href="ViewProfile.aspx" role="button" id="btnViewProfile" class="btn btn-lg btn-block fBtn">View Profile</a>  
               <br />
               <a href="SendProfile.aspx" role="button" id="btnSendProfile" class="btn btn-lg btn-block fBtn">Send Profile</a> 
               <br />
               <a href="Login.aspx" role="button" id="btnLogout" class="btn btn-lg btn-block fBtn">Log Out</a> 
           </div>
           <div id="mainContent" class="col-sm-10">
               <div class="row">
                   <div id="top-header">
                       <div class="col-sm-3">
                           <asp:Label ID="lblSession" runat="server" Text="">Hello</asp:Label>
                       </div>
                       <div class="col-sm-3">
                           <a href="ClientTermsConditions.aspx" id="fContentLeft">Terms & Conditions</a>
                           <a href="ClientContact.aspx" id="fContentRight">Contact us</a>
                       </div>
                       <div class="col-sm-6">
                       
                       </div>
                   </div>
               </div>
               
               <hr />
               <div class="panel panel-default">
                   <div class="panel-heading">Terms & Conditions</div>
                   <div class="panel-body">
                       <form id="editForm" runat="server">
                       <asp:Panel ID="condPanel" runat="server">
                           <h2>Introduction</h2>
                           <p>Follow Me is a service to solve the problem of undelivered mail. Users can quickly and easily update their delivery address with the Follow Me App or Website and enjoy a more convenient service with Follow Me. Follow Me focuses on protecting the user's personal information and personal privacy. This User Agreement & Privacy Policy explains the use of the Personal Information Collection and the User's Privacy Policy. This User Agreement & Privacy Policy applies to all relevant services provided by Follow Me. If you do not agree with any of the contents of the User Agreement & Privacy Policy, you should immediately discontinue the use of Follow Me. When you use any of the services provided by Follow Me, it means that you agree with this User Agreement & Privacy Policy and we will adopt the correct method to protect your personal information and provide the reasonable services.</p>
                           <h2>Usage specifications</h2>
                           <p>1.	Users should provide correct personal details when they first register for the service. Users addresses need to be updated immediately after registration or moving to ensure mail will be delivered to the correct address.2.	After successful registration, the user will be assigned a username and corresponding password. It is for user to use and user should responsible for their all the behaviors of using it in the internet. 3.	During normal use of the Follow Me service, users’ credentials will be verified during login.4.	When using the Follow Me service, the following rules should be complied with:a.	Comply with all the network protocols, rules and regulations of Follow Me services. b.	Any action that using the illegal information, stealing other account information is illegal.c.	Do not attempt to gain unauthorized access to the Follow Me service. If this is detected, your account will be suspended and legal action will be taken.d.	Do not use Follow Me service to conduct unfavorable behavior on the internet running.e.	Follow Me is not intended for public distribution or copying, absent from the express permission of the creators. You agree that you will not copy, download, rent, lease, sell, distribute, transmit, or otherwise transfer all or any portions of the content related to the service.
                           </p>
                           <h2>User privacy policy</h2>
                           <p>Follow Me pay attention on user’s privacy. When you using our services, we might collect and use your related information. We hope use Privacy Policy to show you how we collecting, using, storing and sharing this information and we also provide methods of visiting, updating and protecting the information for you. 
                           </p>
                           <h2>The information we may collect.</h2>
                           <p>As providing the services, we may collect, store and use the following information. If you do not provide relevant information, you may not be able to register as a user or cannot enjoy some of the services we offer, or we cannot achieve the desired results a.	When you register your account or use our services the relevant personal information should be provided, such as phone numbers, e-mails, detail address and bank account. b.	The information you provide to other parties through our services or the information you store when you use our services.
                           </p>
                           <h2>The information we may use.</h2>
                           <p>We may use the information collected in the process of providing you with services for the following purposes:a.	To provide the services for you;b.	To ensure the security of product and service, such as identification, customer service, security and fraud monitoring;c.	Helping us add new services and improve our existing services;d.	To assess and improve the effectiveness of our services and other promotions;e.	Software certification or management software upgrades;f.	To participate in some surveys of our products and services.
                           </p>
                           <h2>The information we may share.</h2>
                           <p>To ensure the privacy of user, Follow Me will not disclose, edit or modify user information except in the following circumstances:a.	Improving the services for you;b.	In the checking and research of some related department (government or police), we might provide users IP, domain name, and registration time and message; c.	In some Follow Me services, we will provide your address to some companies;d.	In the emergency of user and the public privacy security.e.	Maintaining and improving our services. f.	Other situations that Follow Me consider are necessary
                           </p>
                           <h2>How to access and control your own personal information </h2>
                           <p>We will do everything we can to take appropriate technical means to ensure your information security, update and correct your own registration information or use our services to provide other personal information. When accessing, updating, correcting and deleting the account information, we may have the authentication to protect your account.
                           </p>
                           <h2>We may send mail to you</h2>
                           <p>a.	Sending mail and information When you use our services, we may use your information to send e-mails and notifications to your device. If you do not wish to receive this information, you can follow our step and choose close button on your deviceb.	Related announcementsWe may send you the necessary notification in some situations (for example, when the service is close due to system maintenance). You may not be able to cancel these notifications because these not belong to the profit advertising.
                           </p>
                           <h2>The security of user’s Username and Password</h2>
                           <p>When you register successfully, you will get a unique username and password. For account security purposes, keep this information to yourself. Follow Me is not responsible for your account security if you happen to tell someone the password. You may change your password at any time by logging in to the service, or if you have forgotten select ‘forgotten password’ at the login screen. If you happen to find a security bypass or error in the service, please contact the support address below so we can fix it as soon as possible.
                           </p>
                           <h2>Notification and amendment </h2>
                           <p>To ensure the better service to customer, Follow Me services will change from time to time, therefore this User Agreement & Privacy Policy will be updated.</p>
                           <h2>Contact Us</h2>
                           <p>If you have any questions about this User Agreement and Privacy Policies, please do not hesitate to <a href="BusContactUs.aspx">contact us</a>
                               If you do not agree to the terms contained in this User Agreement and Privacy Policy, you will be unable to access and use the service.
                           </p>

                       </asp:Panel>
                           </form>
                   </div>
               </div>
              </div>                    
           </div>
       </div>         
</body>
</html>
