using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.EmailServices
{
    public interface IEmailSender
    {
        // SMTP 

        Task SendEmailAsync(string email, string subject, string htmlMessage);

    }
}