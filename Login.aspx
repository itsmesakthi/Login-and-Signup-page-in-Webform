<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Home.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.3/jquery.min.js"></script>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />

<!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.3/jquery.min.js"></script>

<!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <title>Login and signup</title>
    <style>
        body {            
            background-image: url(bg3.jpg);
            background-size:cover;
            background-repeat: no-repeat;
            font-family: 'Times New Roman', Times, serif;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="col-sm-4" style="padding-left: 0px; padding-right: 0px;">
            </div>
            <div class="col-sm-4" style="padding-left: 0px; padding-right: 0px;backdrop-filter: blur(10px);background-color:transparent;">
                <div> 
                    <h1 style="text-align: center; margin-top: 20px; margin-bottom: 20px;">Login Page</h1>
                </div>
                <div style="margin-bottom: 10px;">
                    <asp:Label runat="server">Username / User Id</asp:Label>
                    <asp:TextBox runat="server" ID="TextUser" CssClass="form-control" placeholder="Enter the Username"></asp:TextBox>
                </div>
                <div style="margin-bottom: 10px;">
                    <asp:Label runat="server">Password</asp:Label>
                    <asp:TextBox runat="server" ID="TextPass" TextMode="Password" CssClass="form-control" placeholder="Enter the Password"></asp:TextBox>
                </div>
                <div style="text-align: center; margin-bottom: 10px;">
                    <asp:Button ID="ButtonLogin" runat="server" CssClass="btn-primary" Text="Login" OnClick="ButtonLogin_Click" />
                    <asp:Button ID="ButtonSignup" runat="server" CssClass="btn-info" Text="Signup" OnClick="ButtonSignup_Click" />
                    <asp:Button ID="ButtonForget" runat="server" CssClass="btn-danger" Text="Forget password" OnClick="ButtonForget_Click"/>
                    <asp:Button ID="ButtonClear" runat="server" CssClass="btn-warning" Text="Clear" OnClick="ButtonClear_Click" />
                </div>
                <div style="background-color: yellow; color: red;">
                    <asp:Label runat="server" ID="LogInfo"></asp:Label>
                </div>
            </div>
            <div class="col-sm-4" style="padding-left: 0px; padding-right: 0px;"></div>
        </div>
    </form>
</body>
</html>

<script>
    //$(document).ready(function () {
    //    //alert("hello");
    //    $("#ButtonLogin").click(function () {
    //        alert("hello")
    //    });

    //});
</script>