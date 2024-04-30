using StudentProfile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentProfile
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RegistrationDatePanel.Visible = false;
                RegisteredStudentsPanel.Visible = false;
                DeletedStudentsReportPanel.Visible = false;
                GetStudents();
                GetDeletedStudents();
                GetRegisteredStudents();
                RegistrationDateReport.Visible = false;
            }
        }

        protected void ReportSubmitButton_Click(object sender, EventArgs e)
        {

        }

        protected void ReportDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ReportDropDownList.SelectedIndex)
            {
                case 1:
                    RegistrationDatePanel.Visible = true;
                    RegisteredStudentsPanel.Visible = false;
                    DeletedStudentsReportPanel.Visible = false;
                    break;
                case 2:
                    RegistrationDatePanel.Visible = false;
                    RegisteredStudentsPanel.Visible = true;
                    DeletedStudentsReportPanel.Visible = false;
                    break;
                case 3:
                    RegistrationDatePanel.Visible = false;
                    RegisteredStudentsPanel.Visible = false;
                    DeletedStudentsReportPanel.Visible = true;                  
                    break;
                default:
                    break;
            }
        }

        public void GetStudents()
        {
            List<Student> students = DataModification.GetStudentsRecords();
            StudentsListGrid.DataSource = students;
            StudentsListGrid.DataBind();
        }

        public void GetDeletedStudents()
        {
            List<Student> students = DataModification.GetDeletedStudentsRecords();
            DeletedStudentsGrid.DataSource = students;
            DeletedStudentsGrid.DataBind();
        }

        public void GetRegisteredStudents()
        {
            List<Student> students = DataReport.ReportDate(DateTime.Parse(ReportRegistrationDateTextBox.Text + DateTime.Now.ToString(" HH:mm:ss.fff")));
            RegistrationDateReport.DataSource = students;
            RegistrationDateReport.DataBind();
        }

        protected void RestoreStudentRecordButton_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in DeletedStudentsGrid.Rows)
            {
                CheckBox deleteCheckBox = (CheckBox)row.FindControl("RestoreStudentsCheckBox");
                if (deleteCheckBox.Checked)
                {
                    int userID = Convert.ToInt32(row.Cells[4].Text);
                    DataModification.RestoreStudentItem(userID);
                }
            }
            GetDeletedStudents();
        }

        protected void GetReportBotton_Click(object sender, EventArgs e)
        {
            RegistrationDateReport.Visible = true;
            GetRegisteredStudents();
        }
    }
}