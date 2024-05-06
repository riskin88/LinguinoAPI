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

            UriBuilder builder = new UriBuilder(_configuration.ResetPasswordUrl);
            builder.Query = "resetToken=" + token + "&email=" + userEmail;
            var link = builder.ToString();

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

            UriBuilder builder = new UriBuilder(_configuration.ChangeEmailUrl);
            builder.Query = "token=" + token + "&oldEmail=" + oldEmail + "&newEmail=" + newEmail;
            var link = builder.ToString();            

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
