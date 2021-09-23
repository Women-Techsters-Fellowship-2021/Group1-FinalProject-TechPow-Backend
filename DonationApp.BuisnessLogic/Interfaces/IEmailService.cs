using DonationApp.DTO.EmailDTO;
using DonationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.BuisnessLogic.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(EmailRequestDTO emailRequestDTO);
        //Task<ServiceResponse<EmailResponseDTO>> SendApplicationCompletedEmail(EmailRequestDTO emailRequestDTO);
        //Task<ServiceResponse<EmailResponseDTO>> SendDonationCompletedVerifcationEmail(EmailRequestDTO emailRequestDTO);


    }
}
