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
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                ForgotPasswordUsernameTextBox.Text = Session["Username"].ToString();
            }
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            bool isValid = ForgotPasswordTextBox.Text != "" && ForgotPasswordUsernameTextBox.Text != "";
            if (isValid)
            {
                Session["Username"] = ForgotPasswordUsernameTextBox.Text;
                Session["Password"] = ForgotPasswordTextBox.Text;
                try
                {
                    using (StudentProfileDataContext studentProfileDataContext = new StudentProfileDataContext(ConfigurationManager.ConnectionStrings["SampleDBConnectionString"].ConnectionString))
                    {
                        DataModification.UpdateUserPassword(studentProfileDataContext, ForgotPasswordUsernameTextBox, ForgotPasswordTextBox);
                    }

                    ClientScript.RegisterStartupScript(this.GetType(), "alert", String.Format("<script>alert('Password Updated Successfully!'); window.open('{0}'); setTimeout(window.close, 1); </script>", "Default.aspx"));
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Error", String.Format("<script>alert('Username does not exists, Please check the entered username or use Sign Up page!'); </script>", true));
                    Session.Clear();
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