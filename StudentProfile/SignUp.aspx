<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="StudentProfile.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SignUp</title>
    <link rel="icon" href="~/Assets/Icons/SignUp.png" type="image/png" />
    <link href="/Content/stylesheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="login" align="center">
                <img src="/Assets/Images/SignUpPage.png" alt="Sign Up Image" width="250" height="250" />
                <br />
                <asp:Label runat="server">Username</asp:Label>
                <asp:TextBox runat="server" ID="SignUpUsernameTextBox" CssClass="txtBox"></asp:TextBox>
                <br />
                <asp:Label runat="server">Email</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox runat="server" ID="SignUpEmailTextBox" CssClass="txtBox" TextMode="Email"></asp:TextBox>
                <br />
                <asp:Label runat="server">Password </asp:Label>
                <asp:TextBox runat="server" ID="SignUpPasswordTextBox" CssClass="txtBox" TextMode="Password"></asp:TextBox>
                <br />

                <div class="btnContainer">
                    <asp:Button runat="server" ID="SubmitBtn" CssClass="btn" OnClick="SubmitBtn_Click" Text="Submit" />
                    <asp:Button runat="server" ID="BackToLogin" CssClass="btn" OnClick="BackToLogin_Click" Text="Back to Login" />
                </div>
                <a href="ForgotPassword.aspx" class="link">Forgot password?</a>
            </div>
        </div>
    </form>
</body>
</html>
