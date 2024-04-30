using StudentProfile.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Net.Configuration;
using System.Text.RegularExpressions;
using System.CodeDom;



namespace StudentProfile
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                ForgotPasswordUsernameTextBox.Text = Session["Email"].ToString();
            }
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            bool isValid = ForgotPasswordUsernameTextBox.Text != "";
            if (isValid)
            {
                Session["username"] = ForgotPasswordUsernameTextBox.Text;
                try
                {
                    using (StudentProfileDataContext studentProfileDataContext = new StudentProfileDataContext(ConfigurationManager.ConnectionStrings["SampleDBConnectionString"].ConnectionString))
                    {
                        var registeredUser = from user in studentProfileDataContext.RegisteredUsers where user.Username == ForgotPasswordUsernameTextBox.Text select user; 
                        //DataModification.UpdateUserPassword(studentProfileDataContext, ForgotPasswordUsernameTextBox, ForgotPasswordTextBox);
                        
                        if (registeredUser != null)
                        {
                            RegisteredUser user = registeredUser.FirstOrDefault();
                            string newPassword = GenerateNewPassword(25);
                            string bluryEmail = user.Email.Substring(0, 4) + "***" + user.Email.Substring(user.Email.LastIndexOf('@'), (user.Email.Length - user.Email.LastIndexOf('@')));
                            SendEMail(user.Email, newPassword, bluryEmail);
                            DataModification.UpdateUserPassword(studentProfileDataContext, user, newPassword );
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", String.Format("<script>alert('Password Sent to {0} Successfully! Use that to login again.'); window.open('{1}'); setTimeout(window.close, 1); </script>", $"{bluryEmail}", "Default.aspx"));
                        }
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

        private void SendEMail(string email, string password, string bluryEmail)
        {

            MailMessage msg = new MailMessage();
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            try
            {
                msg.Subject = "Reset Password";
                msg.Body = $"Your new password is: {password} ";
                msg.From = new MailAddress("mehrnooshziaei2@gmail.com");
                msg.To.Add(email);
                msg.IsBodyHtml = true;
                client.Host = "smtp.gmail.com";
                System.Net.NetworkCredential basicauthenticationinfo = new System.Net.NetworkCredential("mehrnooshziaei2@gmail.com", "3bnV0Z$3%SeYpRd");
                client.Port = int.Parse("587");
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicauthenticationinfo;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(msg);
            }
            catch (Exception ex)
            {
                //throw ExceptionHelper.CreateException(ex);
                ClientScript.RegisterStartupScript(this.GetType(), "Error", String.Format("<script>alert('Error in sending new password to {0}!'); window.open({1}); </script>", $"{bluryEmail}", "ForgotPassword.aspx"));
            }
        }

        private string GenerateNewPassword(int passLength)
        {
            string allowedChars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";
            allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
            allowedChars += "1,2,3,4,5,6,7,8,9,0,!,@,#,$,%,&,?";

            char[] sep = { ',' };
            string[] arr = allowedChars.Split(sep);

            string passwordString = "";
            string temp = "";
            Random rand = new Random();

            for (int i = 0; i < passLength; i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                passwordString += temp;
            }
            return passwordString;
        }
    }
}