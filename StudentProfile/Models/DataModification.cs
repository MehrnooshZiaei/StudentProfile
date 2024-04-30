using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI.WebControls;

//DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")

namespace StudentProfile.Models
{
    public static class DataModification
    {
        public static void ModifyLoginHistory(
            StudentProfileDataContext studentProfileDataContext,
            bool isFirstLogin,
            TextBox LoginUsernameTextBox
            )
        {
            LoginHistory userLoginHistory = new LoginHistory();
            if (!isFirstLogin)
            {
                var previoudUserRecords = studentProfileDataContext.LoginHistories.Where(user => user.Username == LoginUsernameTextBox.Text && user.IsLastLogin == true);
                foreach (var userRecord in previoudUserRecords)
                {
                    userRecord.IsLastLogin = false;
                }
            }
            userLoginHistory.Username = LoginUsernameTextBox.Text;
            userLoginHistory.LastLoginDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            userLoginHistory.IsLastLogin = true;
            studentProfileDataContext.LoginHistories.InsertOnSubmit(userLoginHistory);
            studentProfileDataContext.SubmitChanges();
        }

        public static DateTime UserLastLogin(TextBox LoginUsernameTextBox)
        {
            var userLoginHistory = new LoginHistory();
            using (StudentProfileDataContext studentProfileDataContext = new StudentProfileDataContext(ConfigurationManager.ConnectionStrings["SampleDBConnectionString"].ConnectionString))
            {
                var previouUserRecords = studentProfileDataContext.LoginHistories.Where(user => user.Username == LoginUsernameTextBox.Text && user.IsLastLogin == false);
                if (previouUserRecords.Any())
                {
                    return previouUserRecords.OrderByDescending(user => user.LastLoginDate).FirstOrDefault().LastLoginDate;
                }
                else
                {
                    return studentProfileDataContext.LoginHistories
                        .Where(user => user.Username == LoginUsernameTextBox.Text && user.IsLastLogin == true)
                        .FirstOrDefault().LastLoginDate;
                }
            }
        }

        public static void RegisterNewUser(
                StudentProfileDataContext studentProfileDataContext,
                TextBox SignUpUsernameTextBox,
                TextBox SignUpPasswordTextBox
            )
        {
            //password = PasswordCrypto.HashEncryptStringWithSalt(passwordTextBox.Password, saltValue.ToString());

            //using (SHA512 shaM = new SHA512Managed())
            //{
            //    result = shaM.ComputeHash(SignUpPasswordTextBox.Text);
            //}
            

            RegisteredUser newUser = new RegisteredUser
            {
                Username = SignUpUsernameTextBox.Text,
                Password = SignUpPasswordTextBox.Text,
                RegistrationDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")),
            };
            studentProfileDataContext.RegisteredUsers.InsertOnSubmit(newUser);
            studentProfileDataContext.SubmitChanges();
        }

        public static void UpdateUserPassword(
                StudentProfileDataContext studentProfileDataContext,
                TextBox ForgotPasswordUsernameTextBox,
                TextBox ForgotPasswordTextBox
            )
        {
            RegisteredUser updateUserPassword = studentProfileDataContext.RegisteredUsers.Single(user => user.Username == ForgotPasswordUsernameTextBox.Text);
            updateUserPassword.Password = ForgotPasswordTextBox.Text;
            studentProfileDataContext.SubmitChanges();
        }

        public static void AddStudentData(
                StudentProfileDataContext studentProfileDataContext,
                TextBox AddStudentFirstNameTextBox,
                TextBox AddStudentLastNameTextBox,
                TextBox AddStudentIDTextBox,
                TextBox AddStudentStudentIDTextBox,
                TextBox AddStudentRegistrationDateTextBox
            )
        {
            Student newStudent = new Student
            {
                Firstname = AddStudentFirstNameTextBox.Text,
                Lastname = AddStudentLastNameTextBox.Text,
                ID = Int32.Parse(AddStudentIDTextBox.Text),
                StudentID = Int32.Parse(AddStudentStudentIDTextBox.Text),
                RegistrationDate = DateTime.Parse(AddStudentRegistrationDateTextBox.Text + DateTime.Now.ToString(" HH:mm:ss.fff"))
            };

            studentProfileDataContext.Students.InsertOnSubmit(newStudent);
            studentProfileDataContext.SubmitChanges();
        }

        public static void DeleteStudentItem(int userID)
        {
            using (StudentProfileDataContext studentProfileDataContext = new StudentProfileDataContext(ConfigurationManager.ConnectionStrings["SampleDBConnectionString"].ConnectionString))
            {
                var toBeDeletedStudent = from user in studentProfileDataContext.Students where user.ID == userID select user;
                foreach (var record in toBeDeletedStudent)
                {
                    //studentProfileDataContext.Students.DeleteOnSubmit(record);
                    record.IsDeleted = true;
                    record.DeleteDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                }
                studentProfileDataContext.SubmitChanges();
            }
        }

        public static List<Student> GetStudentsRecords()
        {
            List<Student> students = new List<Student>();
            using (StudentProfileDataContext studentProfileDataContext = new StudentProfileDataContext(ConfigurationManager.ConnectionStrings["SampleDBConnectionString"].ConnectionString))
            {
                var studentsList = from user in studentProfileDataContext.Students where !user.IsDeleted select user;
                foreach (var record in studentsList)
                {
                    students.Add(new Student
                    {
                        StudentID = record.StudentID,
                        ID = record.ID,
                        Firstname = record.Firstname,
                        Lastname = record.Lastname,
                        RegistrationDate = record.RegistrationDate
                    });
                }
            }
            return students;
        }

        public static List<Student> GetDeletedStudentsRecords()
        {
            List<Student> deletedStudents = new List<Student>();
            using (StudentProfileDataContext studentProfileDataContext = new StudentProfileDataContext(ConfigurationManager.ConnectionStrings["SampleDBConnectionString"].ConnectionString))
            {
                var studentsList = from user in studentProfileDataContext.Students where user.IsDeleted select user;
                foreach (var record in studentsList)
                {
                    deletedStudents.Add(new Student
                    {
                        StudentID = record.StudentID,
                        ID = record.ID,
                        Firstname = record.Firstname,
                        Lastname = record.Lastname,
                        RegistrationDate = record.RegistrationDate,
                        DeleteDate = record.DeleteDate,
                    });
                }
            }
            return deletedStudents;
        }

        public static void RestoreStudentItem(int userID)
        {
            using (StudentProfileDataContext studentProfileDataContext = new StudentProfileDataContext(ConfigurationManager.ConnectionStrings["SampleDBConnectionString"].ConnectionString))
            {
                var toBeDeletedStudent = from user in studentProfileDataContext.Students where user.ID == userID && user.IsDeleted select user;
                foreach (var record in toBeDeletedStudent)
                {
                    //studentProfileDataContext.Students.DeleteOnSubmit(record);
                    record.IsDeleted = false;
                    record.DeleteDate = null;
                }
                studentProfileDataContext.SubmitChanges();
            }
        }
    }
}