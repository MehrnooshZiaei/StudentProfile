<%@ Page Language="C#" Title="Delete Student" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteStudent.aspx.cs" Inherits="StudentProfile.DeleteStudent" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <hr />
    <h3>Here You can delete a student. Please choose the supposed student to delete</h3>

    <table style="border: 1px solid black">
        <thead>
            <tr>
                <th></th>
                <th style="border: 1px solid black">Student ID</th>
                <th style="border: 1px solid black">Firstname</th>
                <th style="border: 1px solid black">Lastname</th>
                <th style="border: 1px solid black">ID</th>
                <th style="border: 1px solid black">Registration Date</th>
            </tr>
        </thead>
        <tbody>
            <% foreach (StudentProfile.Models.Student student in this.RegisteredStudents)
                { %>
            <tr style="border: 1px solid black">

                <td style="border: 1px solid black; text-align: center">
                    <asp:CheckBox runat="server" ID="StudentsCheckBox" OnCheckedChanged="StudentsCheckBox_CheckedChanged" StudentUserID="<%=student.ID %>" /></td>

                <td style="border: 1px solid black; text-align: center">
                    <label><%=student.StudentID %></label></td>

                <td style="border: 1px solid black; text-align: center">
                    <label><%=student.Firstname %></label></td>

                <td style="border: 1px solid black; text-align: center">
                    <label><%=student.Lastname %></label></td>
                <td style="border: 1px solid black; text-align: center" >
                    <label><%=student.ID %></label></td>
                <td style="border: 1px solid black; text-align: center">
                    <label><%=student.RegistrationDate %></label></td>
            </tr>
            <% }%>
        </tbody>
    </table>
    <br />
    <asp:Button runat="server" ID="DeleteStudentRecordButton" OnClick="DeleteStudentRecordButton_Click" Text="Delete" OnClientClick="return confirm('Are you sure to delete?');" CssClass="btn"/>

</asp:Content>
