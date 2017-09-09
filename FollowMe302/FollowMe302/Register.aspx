<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FollowMe302.Register" %>

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
            <img src="images/signUp.png" class="img-responsive center" id="front-logo" />
            <br />
            <div class="form-group">
                <asp:TextBox ID="userNameRegister" runat="server" placeholder="userName" CssClass="form-control"></asp:TextBox>                
            </div>

            <div class="form-group">
                <asp:TextBox ID="pwdRegister" runat="server" placeholder="password" CssClass="form-control"></asp:TextBox>                  
            </div>

            <div class="form-group">
                <div class="col-sm-6">
                    <div id="pu" class="radio">
                        <label><input type="radio" name="optradio">Personal Use</label>
                    </div>
                </div>

                <div class="col-sm-6">
                    <div id="bu" class="radio">
                        <label><input type="radio" name="optradio">Business Use</label>
                    </div>
                </div>
            </div>
           <asp:Button ID="btnRegisterPage" runat="server" CssClass="btn btn-primary btn-lg btn-block fBtn" Text="Register" OnClick="btnRegisterPage_Click" />
           <asp:Label ID="lblRegStatus" runat="server"></asp:Label>
            

        </form>

    </div>
    
</body>
</html>
