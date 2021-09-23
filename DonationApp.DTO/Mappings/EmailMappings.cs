using DonationApp.DTO.EmailDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.DTO.Mappings
{
    public class EmailMappings
    {
        public static EmailResponseDTO  GetEmailResponse (EmailRequestDTO emailRequestDTO)
        {
            return new EmailResponseDTO
            {
                ToEmail = emailRequestDTO.ToEmail,
                Subject = emailRequestDTO.Subject,
                Body = emailRequestDTO.Subject
            
            };
        }
    }
}
