using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace StudentProfile.Models
{
    public static class DataReport
    {
        public static List<Student> ReportDate(DateTime date)
        {
            List<Student> students = new List<Student>();
            using (StudentProfileDataContext studentProfileDataContext = new StudentProfileDataContext(ConfigurationManager.ConnectionStrings["SampleDBConnectionString"].ConnectionString))
            {
                var studentsList = from user in studentProfileDataContext.Students where !user.IsDeleted && user.RegistrationDate < date select user;
                foreach (var record in studentsList)
                {
                    students.Add(new Student
                    {
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
    }
}