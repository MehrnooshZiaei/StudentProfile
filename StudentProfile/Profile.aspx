<%@ Page Language="C#" Title="Home" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="StudentProfile.Profile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <h3>Welcome <%= Server.HtmlEncode((string)Session["Username"]) %>.</h3>
    <p>Your last login date is <%= Server.HtmlEncode((string)Session["LastLogin"]) %>.</p>
</asp:Content>