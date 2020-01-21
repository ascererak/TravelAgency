using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Interfaces.Dto;
using TravelAgency.Services.Interfaces.Handlers;

namespace TravelAgency.Services.Handlers
{
    internal class MailHandler : IMailHandler
    {
        public async Task SendMailAsync(EmailData emailData, string receiverAddress)
        {
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress(emailData.Name, emailData.Email);
            message.From.Add(from);

            message.Subject = emailData.Subject;

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = emailData.Message;

            message.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.Connect("in-v3.mailjet.com", 25);
            client.Authenticate("d1cfa5ab85d11b8a187896228e302d47", "76e540cfabacf6390a5b6caa59800f14");
            
            MailboxAddress to = new MailboxAddress(receiverAddress);
            message.To.Add(to);

            await client.SendAsync(message);
            
            client.Disconnect(true);
            client.Dispose();
        }
    }
}
