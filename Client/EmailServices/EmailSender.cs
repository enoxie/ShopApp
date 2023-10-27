using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Client.EmailServices
{
    public class EmailSender : IEmailSender
    {
        private string _host;
        private int _port;
        private bool _enabledSSL;
        private string _username;
        private string _password;

        public EmailSender(string host, int port, bool enabledSSL, string username, string password)
        {
            this._host = host;
            this._port = port;
            this._enabledSSL = enabledSSL;
            this._username = username;
            this._password = password;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient(this._host, this._port)
            {
                Credentials = new NetworkCredential(_username, _password),
                EnableSsl = this._enabledSSL
            };

            return client.SendMailAsync(
                new MailMessage(this._username, email, subject, htmlMessage)
                {
                    IsBodyHtml = true
                }
            );
        }
    }
}