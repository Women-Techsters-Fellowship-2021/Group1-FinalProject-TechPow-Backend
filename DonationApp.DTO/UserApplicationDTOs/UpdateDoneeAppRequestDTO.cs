using DonationApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.DTO.UserApplicationDTOs
{
    public class UpdateDoneeAppRequestDTO
    {
        public string HomeAddress { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string EduLevel { get; set; }
        public string ImageLink { get; set; }
        public string ApplicationStatus { get; set; }

    }
    
}
