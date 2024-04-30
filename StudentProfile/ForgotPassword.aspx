<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="StudentProfile.ResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>
    <link rel="icon" href="~/Assets/Icons/ForgotPassword.png" type="image/png" />
    <link href="/Content/stylesheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="login" align="center">
                <img src="/Assets/Images/ForgotPasswordPage.png" alt="Forgot Password Image" width="250" height="250" />
                <br />
                <asp:Label runat="server">Username</asp:Label>
                <asp:TextBox runat="server" ID="ForgotPasswordUsernameTextBox" CssClass="txtBox"></asp:TextBox>
                <br />

                <div class="btnContainer">
                    <asp:Button runat="server" ID="SubmitBtn" CssClass="btn" OnClick="SubmitBtn_Click" Text="Password Recovery" />
                    <asp:Button runat="server" ID="BackToLogin" CssClass="btn" OnClick="BackToLogin_Click" Text="Back to Login" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
