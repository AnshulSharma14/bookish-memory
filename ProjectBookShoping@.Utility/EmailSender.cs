using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBookShoping.Utility
{
	public class EmailSender : IEmailSender
	{
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var emailTosend = new MimeMessage();
            emailTosend.From.Add(MailboxAddress.Parse("anshul1906031014@gmail.com"));
            emailTosend.To.Add(MailboxAddress.Parse(email));
            emailTosend.Subject = subject;
            emailTosend.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlMessage };

            using (var emailClient = new SmtpClient())
            {
                emailClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                emailClient.Authenticate("anshul1906031014@gmail.com", "wumcentmnhwutvud");
                emailClient.Send(emailTosend);
                emailClient.Disconnect(true);
            }
            return Task.CompletedTask;
        }
    }
}
