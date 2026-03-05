using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading.Tasks;
using eVote360.Shared.Email;

namespace eVote360.Infrastructure.Services
{
    public class EmailService : IEmailSender
    {
        public Task SendEmailAsync(string to, string subject, string htmlMessage)
        {
            // Implementación real vendrá después (MailKit).
            
            throw new System.NotImplementedException();
        }
    }
}

