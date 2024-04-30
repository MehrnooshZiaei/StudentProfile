<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StudentProfile.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome</title>
    <link rel="icon" href="~/Assets/Icons/Login.png" type="image/png" />
    <link href="/Content/stylesheet.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="login" align="center">
                <img src="/Assets/Images/LoginPage.jpg" alt="Student Profile Login Image" width="300" height="250" />
                <br />
                <asp:Label runat="server">Username/Email</asp:Label>
                <asp:TextBox runat="server" ID="LoginUsernameTextBox" CssClass="txtBox" ></asp:TextBox>
                <br />

                <asp:Label runat="server" >Password </asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox runat="server" ID="LoginPasswordTextBox" CssClass="txtBox" TextMode="Password" ></asp:TextBox>
                <br />

                <div class="btnContainer">
                    <asp:Button runat="server" ID="LoginBtn" CssClass="btn" OnClick="LoginBtn_Click" Text="Login" />
                    <asp:Button runat="server" ID="SignUpBtn" CssClass="btn" OnClick="SignUpBtn_Click" Text="Sign Up" />
                </div>
                
                <a href="ForgotPassword.aspx" class="link" >Forgot password?</a>
            </div>
        </div>
    </form>
</body>
</html>
