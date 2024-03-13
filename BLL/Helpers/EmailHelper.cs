using BLL.Config;
using BLL.Exceptions.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Specialized;
using System.Net.Mail;

namespace BLL.Helpers
{
    public class EmailHelper
    {
        private readonly EmailSettings _configuration;

        public EmailHelper(IOptions<EmailSettings> configuration)
        {
            _configuration = configuration.Value;
        }
        public void SendEmailPasswordReset(string userEmail, string token)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_configuration.Address);
            mailMessage.To.Add(new MailAddress(userEmail));

            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(_configuration.ResetPasswordUrl);
            queryString.Add("resetToken", token);
            queryString.Add("email", userEmail);
            var link = queryString.ToString();

            mailMessage.Subject = "Password Reset";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = link;

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(_configuration.Address, _configuration.Password);
            client.Host = _configuration.Host;
            client.Port = _configuration.Port;
            client.EnableSsl = true;

            try
            {
                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw new EmailErrorException("Oops, something went wrong while sending the e-mail.");
            }
        }

        public void SendEmailChangeEmail(string oldEmail, string newEmail, string token)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_configuration.Address);
            mailMessage.To.Add(new MailAddress(newEmail));

            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(_configuration.ChangeEmailUrl);
            queryString.Add("token", token);
            queryString.Add("oldEmail", oldEmail);
            queryString.Add("newEmail", newEmail);
            var link = queryString.ToString();
            

            mailMessage.Subject = "Confirm Email Change";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = link;

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(_configuration.Address, _configuration.Password);
            client.Host = _configuration.Host;
            client.Port = _configuration.Port;
            client.EnableSsl = true;

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
