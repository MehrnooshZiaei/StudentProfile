using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentProfile.Models;
using System.Configuration;
using System.Security.Principal;
using System.ComponentModel.Design;
using System.Data.Linq;


namespace StudentProfile
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
            }

            if (Session["Username"] != null)
            {
                LoginUsernameTextBox.Text = Session["Username"].ToString();
            }
                
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            bool isValid = LoginUsernameTextBox.Text != "" && LoginPasswordTextBox.Text != "";

            if (isValid)
            {
                if (LoginUsernameTextBox.Text.Contains("@"))
                {
                    Session["Email"] = LoginUsernameTextBox.Text;
                }
                else
                {
                    Session["Username"] = LoginUsernameTextBox.Text;
                }
                Session["Password"] = LoginPasswordTextBox.Text;
                using (StudentProfileDataContext studentProfileDataContext = new StudentProfileDataContext(ConfigurationManager.ConnectionStrings["SampleDBConnectionString"].ConnectionString))
                {
                    var registeredUsers = from user in studentProfileDataContext.RegisteredUsers select user;

                    if (!registeredUsers.Any(u => u.Username == LoginUsernameTextBox.Text) && !registeredUsers.Any(u => u.Email == LoginUsernameTextBox.Text))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Error", String.Format("<script>alert('Username does not exists, Please check the entered username or click on Sign Up to register new user!'); </script>", true));
                        Session.Clear();
                    }
                    if (!registeredUsers.Any(user => user.Password == Cryptography.Encode(LoginPasswordTextBox.Text)))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Error", String.Format("<script>alert('Password is not correct, Please check the entered password or click on Forgot Password to reset your password!'); </script>", true));
                    }
                    else
                    {
                        
                        bool isFirstLogin = !studentProfileDataContext.LoginHistories.Any(user => user.Username == LoginUsernameTextBox.Text);
                        DataModification.ModifyLoginHistory(studentProfileDataContext, isFirstLogin, LoginUsernameTextBox);



                        Session["LastLogin"] = DataModification.UserLastLogin(LoginUsernameTextBox).ToString();

                        ClientScript.RegisterStartupScript(this.GetType(), "alert", String.Format("<script>alert('Login Successfully!'); window.open('{0}'); setTimeout(window.close, 0.1); </script>", "Profile.aspx"));
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Error", String.Format("<script>alert('Please input all the required fields correctly!'); </script>", true));
            }
        }
        
        protected void SignUpBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }

        
    }
}