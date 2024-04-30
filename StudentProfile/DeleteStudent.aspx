<%@ Page Language="C#" Title="Delete Student" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteStudent.aspx.cs" Inherits="StudentProfile.DeleteStudent" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <hr />
    <h3>Here You can delete a student. Please choose the supposed student to delete</h3>

    <asp:GridView ID="DeleteStudentsGrid" runat="server" AutoGenerateColumns="false" CellPadding="4">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox runat="server" ID="DeleteStudentsCheckBox" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="StudentID" HeaderText="Student ID" />
            <asp:BoundField DataField="Firstname" HeaderText="Firstname" />
            <asp:BoundField DataField="Lastname" HeaderText="Lastname" />
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="RegistrationDate" HeaderText="Registration Date" />
        </Columns>
        <HeaderStyle BackColor="#5766CE" ForeColor="#ffffff" />
        <RowStyle BackColor="#ffffff" />
    </asp:GridView>

    <br />
    <asp:Button runat="server" ID="DeleteStudentRecordButton" OnClick="DeleteStudentRecordButton_Click" Text="Delete" OnClientClick="return confirm('Are you sure to delete?');" CssClass="btn" />

</asp:Content>
