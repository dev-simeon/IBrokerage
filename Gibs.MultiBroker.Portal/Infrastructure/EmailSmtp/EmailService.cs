﻿using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;

namespace Gibs.Infrastructure.Email
{
    public class EmailService(IOptions<SmtpSettings> smtpSettings)
    {
        private readonly SmtpSettings _smtpSettings = smtpSettings.Value;

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient
            {
                Host = _smtpSettings.Host,
                Port = _smtpSettings.Port,
                Credentials = new NetworkCredential(_smtpSettings.UserName, _smtpSettings.Password),
                EnableSsl = true,
            };

            var message = new MailMessage
            {
                From = new MailAddress(_smtpSettings.SenderEmail, _smtpSettings.SenderName),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true,
            };

            message.To.Add(email);

            return client.SendMailAsync(message);
        }
    }

}
