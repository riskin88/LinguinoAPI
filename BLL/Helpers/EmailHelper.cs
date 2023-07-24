using BLL.Exceptions.User;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Helpers
{
    public class EmailHelper
    {
        private readonly IConfiguration _configuration;

        public EmailHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SendEmailPasswordReset(string userEmail, string token)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_configuration["Email:Address"]);
            mailMessage.To.Add(new MailAddress(userEmail));

            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString("Email:ResetPasswordUrl");
            queryString.Add("token", token);
            queryString.Add("email", userEmail);
            var link = queryString.ToString();

            mailMessage.Subject = "Password Reset";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = link;

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(_configuration["Email:Adress"], _configuration["Email:Password"]);
            client.Host = _configuration["Email:Host"];
            client.Port = Int32.Parse(_configuration["Email:Port"]);

            try
            {
                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw new EmailErrorException("Oops, something went wrong while sending the e-mail.");
            }
        }
    }
}
