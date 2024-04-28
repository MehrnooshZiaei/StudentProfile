using StudentProfile.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentProfile
{
    public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Random R = new Random();
            long studentID = (long)R.Next(0, 100000) * (long)R.Next(0, 100000);
            AddStudentStudentIDTextBox.Text = studentID.ToString();

        }

        protected void AddStudentInfoButton_Click(object sender, EventArgs e)
        { 
            bool isValid = AddStudentFirstNameTextBox.Text != "" &&
                AddStudentLastNameTextBox.Text != "" &&
                AddStudentIDTextBox.Text != "" &&
                //AddStudentStudentIDTextBox.Text != "" &&
                AddStudentRegistrationDateTextBox.Text != "";
            if (isValid)
            {
                using (StudentProfileDataContext studentProfileDataContext = new StudentProfileDataContext(ConfigurationManager.ConnectionStrings["SampleDBConnectionString"].ConnectionString))
                {
                    Student newStudent = new Student();
                    newStudent.name = AddStudentFirstNameTextBox.Text;
                    newStudent.lastname = AddStudentLastNameTextBox.Text;
                    newStudent.id = Int32.Parse(AddStudentIDTextBox.Text);
                    newStudent.student_id = Int32.Parse(AddStudentStudentIDTextBox.Text);

                    string sqlFormattedDate = Convert.ToDateTime(AddStudentRegistrationDateTextBox.Text).ToString("yyyy-MM-dd HH:mm:ss.fff");
                    newStudent.registration_date = sqlFormattedDate;

                    studentProfileDataContext.Students.InsertOnSubmit(newStudent);
                    studentProfileDataContext.SubmitChanges();
                }
                ClientScript.RegisterStartupScript(this.GetType(), "alert", String.Format("<script>alert('Student Successfully Added!'); </script>", true));
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Error", String.Format("<script>alert('Please input all the required fields correctly!'); </script>", true));
            }
            
        }
    }
}