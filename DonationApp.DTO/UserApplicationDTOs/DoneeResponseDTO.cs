using DonationApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.DTO.UserApplicationDTOs
{
    public class DoneeResponseDTO
    {
        public DateTime DOB { get; set; }
        public string ItemNeeded { get; set; }
        public Gender Gender { get; set; }
        public CareerStatus CareerStatus { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string ShortBio { get; set; }
        public string ImageLink { get; set; }
        public string PhoneNumber { get; set; }
        public TechStack TechStack { get; set; }
    }
}
