using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Interfaces.DatabaseAccess.Repositories;
using TravelAgency.Interfaces.Dto;
using TravelAgency.Interfaces.Dto.Models;
using TravelAgency.Interfaces.Services;
using TravelAgency.Services.Interfaces.Handlers;

namespace TravelAgency.Services
{
    public class SubscriberService : ISubscriberService
    {
        private readonly ISubscriberRepository subscriberRepository;
        private readonly IMailHandler mailHandler;

        public SubscriberService(ISubscriberRepository subscriberRepository, IMailHandler mailHandler)
        {
            this.subscriberRepository = subscriberRepository;
            this.mailHandler = mailHandler;
        }

        public async Task AddAsync(string subscriberEmail)
        {
            await subscriberRepository.AddAsycn(subscriberEmail);
        }

        public async Task SendEmailAsync()
        {
            IReadOnlyCollection<SubscriberData> subscribers = await subscriberRepository.GetAsync();

            string newsLink = "https://www.google.com.ua";
            string message = "<p>Hey! Check out our latest news by the link below: " +
                $"<a href='{newsLink}'>Link</a></p>";
            string name = "Carpe diem travel agency";
            string email = "carpediem@travel.agency";
            string subject = "Latest news";

            foreach (var subscriber in subscribers)
            {
                EmailData emailData = new EmailData
                {
                    Message = message,
                    Email = email,
                    Name = name,
                    Subject = subject
                };

                await mailHandler.SendMailAsync(emailData, subscriber.Email);
            }
        }
    }
}
