<%@ Page Language="C#" Title="Report" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="StudentProfile.Report" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <hr />
    <h3>Choose the report you want to have.</h3>
    <td style="text-align: center">
        <asp:DropDownList runat="server" ID="ReportDropDownList" Width="400px" CssClass="dropDownList" OnSelectedIndexChanged="ReportDropDownList_SelectedIndexChanged">
            <asp:ListItem Enabled="true" Text="------Select Your Report------" Value="-1"></asp:ListItem>
            <asp:ListItem Text="Report based on students registration date" Value="1"></asp:ListItem>
            <asp:ListItem Text="Report to show all registered students" Value="2"></asp:ListItem>
            <asp:ListItem Text="Report to show deleted students" Value="3"></asp:ListItem>
        </asp:DropDownList>
    </td>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button runat="server" ID="ReportSubmitButton" OnClick="ReportSubmitButton_Click" Text="Submit" CssClass="btn" />

    <asp:Panel runat="server" ID="RegistrationDatePanel">
        <br />
        <br />
        <p>Choose date to search for students with registration date before that:</p>
        <asp:TextBox runat="server" ID="ReportRegistrationDateTextBox" TextMode="Date" Width="203px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button runat="server" ID="GetReportBotton" OnClick="GetReportBotton_Click" Text="Get Report" CssClass="btn" />
        <br /><br />

        <asp:GridView ID="RegistrationDateReport" runat="server" AutoGenerateColumns="false" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="StudentID" HeaderText="Student ID" />
                <asp:BoundField DataField="Firstname" HeaderText="Firstname" />
                <asp:BoundField DataField="Lastname" HeaderText="Lastname" />
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="RegistrationDate" HeaderText="Registration Date" />
            </Columns>
            <HeaderStyle BackColor="#5766CE" ForeColor="#ffffff" />
            <RowStyle BackColor="#ffffff" />
        </asp:GridView>

    </asp:Panel>

    <asp:Panel runat="server" ID="RegisteredStudentsPanel">
        <br />
        <br />
        <p>The students list is as follows:</p>
        <asp:GridView ID="StudentsListGrid" runat="server" AutoGenerateColumns="false" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="StudentID" HeaderText="Student ID" />
                <asp:BoundField DataField="Firstname" HeaderText="Firstname" />
                <asp:BoundField DataField="Lastname" HeaderText="Lastname" />
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="RegistrationDate" HeaderText="Registration Date" />
            </Columns>
            <HeaderStyle BackColor="#5766CE" ForeColor="#ffffff" />
            <RowStyle BackColor="#ffffff" />
        </asp:GridView>
    </asp:Panel>

    <asp:Panel runat="server" ID="DeletedStudentsReportPanel">
        <br />
        <br />
        <p>Here you can see the deleted students list, Check the checkbox for any item that you want to be restored:</p>
        <asp:GridView ID="DeletedStudentsGrid" runat="server" AutoGenerateColumns="false" CellPadding="4">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="RestoreStudentsCheckBox" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="StudentID" HeaderText="Student ID" />
                <asp:BoundField DataField="Firstname" HeaderText="Firstname" />
                <asp:BoundField DataField="Lastname" HeaderText="Lastname" />
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="RegistrationDate" HeaderText="Registration Date" />
                <asp:BoundField DataField="DeleteDate" HeaderText="Delete Date" />
            </Columns>
            <HeaderStyle BackColor="#5766CE" ForeColor="#ffffff" />
            <RowStyle BackColor="#ffffff" />
        </asp:GridView>

        <br />
        <asp:Button runat="server" ID="RestoreStudentRecordButton" OnClick="RestoreStudentRecordButton_Click" Text="Restore" OnClientClick="return confirm('Are you sure to Restore?');" CssClass="btn" />
    </asp:Panel>

</asp:Content>
