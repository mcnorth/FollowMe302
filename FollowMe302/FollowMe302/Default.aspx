﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FollowMe302.Default" %>

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
    <div class="container">
        <form id="form1" runat="server">
            <div id="bg">
            <img src="images/front-logo.png" class="img-responsive center" id="front-logo" />
            <br />
            <div class="form-group">
                <a href="Login.aspx" role="button" id="btnLogin" class="btn btn-primary btn-lg btn-block fBtn">Login</a> 
                <%--<label for="email">Email address:</label>
                <input type="email" class="form-control" id="email"/>--%>

            </div>
            <div class="form-group">
                <a href="Register.aspx" role="button" id="btnRegister" class="btn btn-primary btn-lg btn-block fBtn">Register</a> 
                <%--<label for="pwd">Password:</label>
                <input type="password" class="form-control" id="pwd"/>--%>

            </div>
            <%--<div class="checkbox">
                <label><input type="checkbox"/> Remember me</label>

            </div>
            <button type="submit" class="btn btn-default">Submit</button>--%>

                </div>

        </form>

    </div>
    
</body>
</html>
