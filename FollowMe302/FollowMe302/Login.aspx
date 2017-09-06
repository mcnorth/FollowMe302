<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FollowMe302.Login" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="css/main.css"/>
    <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css"/>
    <script src="scripts/bootstrap.min.js"></script>
    <script src="scripts/jquery-3.2.1.min.js"></script>
    
    <title></title>
</head>
<body style="background-color:#8cc63e">
    <div class="container">
        <form id="form1" runat="server">
            <img src="images/login.png" class="img-responsive center" id="front-logo" />
            <br />
            <div class="form-group">
                <label for="userName">username:</label>
                <input type="text" class="form-control" id="userNameLogin">
                
                

            </div>
            <div class="form-group">
                
                <label for="pwd">password:</label>
                <input type="password" class="form-control" id="pwdLogin"/>

            </div>
            <%--<div class="checkbox">
                <label><input type="checkbox"/> Remember me</label>

            </div>--%>

            <button type="button" id="btnLoginPage" class="btn btn-primary btn-lg btn-block fBtn">login</button>

        </form>

    </div>
    
</body>
</html>
