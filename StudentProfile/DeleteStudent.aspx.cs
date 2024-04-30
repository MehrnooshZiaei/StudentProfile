using StudentProfile.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentProfile
{
    public partial class DeleteStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetStudents();
            }
        }

        public void GetStudents()
        {
            List<Student> students = DataModification.GetStudentsRecords();
            DeleteStudentsGrid.DataSource = students;
            DeleteStudentsGrid.DataBind();
        }

        protected void DeleteStudentRecordButton_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in DeleteStudentsGrid.Rows)
            {
                CheckBox deleteCheckBox = (CheckBox)row.FindControl("DeleteStudentsCheckBox");
                if (deleteCheckBox.Checked)
                {
                    int userID = Convert.ToInt32(row.Cells[4].Text);
                    DataModification.DeleteStudentItem(userID);
                }
            }
            GetStudents();
        }
    }
}