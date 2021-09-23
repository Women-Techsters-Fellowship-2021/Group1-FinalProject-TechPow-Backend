﻿using DonationApp.BuisnessLogic.Interfaces;
using DonationApp.DTO.EmailDTO;
using DonationApp.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.BuisnessLogic.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly MailSettings _mailSettings;
        public EmailService(IOptions<MailSettings> options)
        {
            _mailSettings =options.Value;  
        }
        
        public async Task SendEmail(EmailRequestDTO emailRequestDTO)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(emailRequestDTO.ToEmail));
            email.Subject = emailRequestDTO.Subject;
            var bodybuilder = new BodyBuilder();

            bodybuilder.HtmlBody = emailRequestDTO.Body;
            email.Body = bodybuilder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
        }

        //public Task<ServiceResponse<EmailResponseDTO>> SendDonationCompletedVerifcationEmail(EmailRequestDTO emailRequestDTO)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ServiceResponse<EmailResponseDTO>> SendVerifcationEmail(EmailRequestDTO emailRequestDTO)
        //{
        //    throw new NotImplementedException();
        //}
    }
}