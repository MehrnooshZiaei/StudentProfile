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
            long studentID = (long)R.Next(0, 10000) * (long)R.Next(0, 10000);
            AddStudentStudentIDTextBox.Text = studentID.ToString();

        }

        protected void AddStudentInfoButton_Click(object sender, EventArgs e)
        {
            bool isValid = AddStudentFirstNameTextBox.Text != "" &&
                AddStudentLastNameTextBox.Text != "" &&
                AddStudentIDTextBox.Text != "" &&
                AddStudentRegistrationDateTextBox.Text != "";
            if (isValid)
            {
                using (StudentProfileDataContext studentProfileDataContext = new StudentProfileDataContext(ConfigurationManager.ConnectionStrings["SampleDBConnectionString"].ConnectionString))
                {
                    DataModification.AddStudentData(
                        studentProfileDataContext,
                        AddStudentFirstNameTextBox,
                        AddStudentLastNameTextBox,
                        AddStudentIDTextBox,
                        AddStudentStudentIDTextBox,
                        AddStudentRegistrationDateTextBox
                    );
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