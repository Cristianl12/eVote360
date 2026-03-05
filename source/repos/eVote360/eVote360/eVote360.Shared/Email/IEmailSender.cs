using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVote360.Shared.Email
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string to, string subject, string htmlMessage);
    }
}
