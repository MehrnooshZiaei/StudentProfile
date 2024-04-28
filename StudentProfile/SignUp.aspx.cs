using StudentProfile.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentProfile
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            bool isValid = SignUpPasswordTextBox.Text != "" && SignUpUsernameTextBox.Text != ""; 
            if (isValid)
            {
                Session["Username"] = SignUpUsernameTextBox.Text;
                Session["Password"] = SignUpPasswordTextBox.Text;
                try
                {
                    using (StudentProfileDataContext studentProfileDataContext = new StudentProfileDataContext(ConfigurationManager.ConnectionStrings["SampleDBConnectionString"].ConnectionString))
                    {
                        RegisteredUser newUser = new RegisteredUser
                        {
                            username = SignUpUsernameTextBox.Text,
                            password = SignUpPasswordTextBox.Text
                        };
                        studentProfileDataContext.RegisteredUsers.InsertOnSubmit(newUser);
                        studentProfileDataContext.SubmitChanges();
                    }
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", String.Format("<script>alert('Registration Successful!'); window.open('{0}'); setTimeout(window.close, 1); </script>", "Default.aspx"));
                } 
                catch (Exception ex)
                {
                    if (ex.Message.Contains("duplicate key value"))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Error", String.Format("<script>alert('Error: Entered username is already in use, choose another one or use forget password!'); </script>", true));
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Error", String.Format("<script>alert('Please input all the required fields correctly!'); </script>", true));
            }
        }

        protected void BackToLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}