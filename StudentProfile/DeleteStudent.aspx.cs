using StudentProfile.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentProfile
{
    public partial class DeleteStudent : System.Web.UI.Page
    {

        public List<Student> RegisteredStudents { get; set; }
        public List<int> ToBeDeletedStudentIDs { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RegisteredStudents = GetStudents();
                
            }
            
        }

        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            using (StudentProfileDataContext studentProfileDataContext = new StudentProfileDataContext(ConfigurationManager.ConnectionStrings["SampleDBConnectionString"].ConnectionString))
            {
                var studentsList = from user in studentProfileDataContext.Students select user;
                foreach (var record in studentsList)
                {
                    students.Add(new Student{
                        StudentID = record.StudentID,
                        ID = record.ID,
                        Firstname = record.Firstname,
                        Lastname = record.Lastname,
                        RegistrationDate = record.RegistrationDate,
                    });
                }
            }
            return students;
        }

        protected void StudentsCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            //string res = StudentsCheckBox.Attributes["StudentUserID"].ToString();

            //ToBeDeletedStudentIDs.Add(int.Parse(StudentsCheckBox.Attributes["StudentUserID"].ToString()));

            
        }

        protected void DeleteStudentRecordButton_Click(object sender, EventArgs e)
        {
            
            
                using (StudentProfileDataContext studentProfileDataContext = new StudentProfileDataContext(ConfigurationManager.ConnectionStrings["SampleDBConnectionString"].ConnectionString))
            {
                foreach (var id in ToBeDeletedStudentIDs)
                {
                    var record = studentProfileDataContext.Students.Where(user => user.ID == id).FirstOrDefault();
                    studentProfileDataContext.Students.DeleteOnSubmit(record);
                }
                
            }
        }
    }
}