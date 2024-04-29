<%@ Page Language="C#" Title="Add Student" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="StudentProfile.AddStudent" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <hr />
    <h3>Here You can add a student. To do so, please fill the following fields.</h3>

    <table>
        <tr>
            <td><asp:Label runat="server">Firstname</asp:Label></td> 
            <td><asp:TextBox runat="server" ID="AddStudentFirstNameTextBox" width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label runat="server">Lastname</asp:Label></td>
            <td><asp:TextBox runat="server" ID="AddStudentLastNameTextBox" width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label runat="server">ID</asp:Label></td>
            <td><asp:TextBox runat="server" ID="AddStudentIDTextBox" TextMode="Number" width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label runat="server">StudentID</asp:Label></td>
            <td><asp:TextBox runat="server" ID="AddStudentStudentIDTextBox" TextMode="Number" width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label runat="server">Registration Date</asp:Label></td>
            <td><asp:TextBox runat="server" ID="AddStudentRegistrationDateTextBox" TextMode="Date" width="203px"></asp:TextBox></td>
        </tr>
    </table>
    
    <br />
    <asp:Button runat="server" ID="AddStudentInfoButton" Text="Submit" CssClass="btn" OnClick="AddStudentInfoButton_Click" />

</asp:Content>
