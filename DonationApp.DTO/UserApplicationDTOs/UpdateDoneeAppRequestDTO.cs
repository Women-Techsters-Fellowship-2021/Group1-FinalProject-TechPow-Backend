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
        public string PhoneNumber { get; set; }
        public CareerStatus CareerStatus { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string ShortBio { get; set; }
        public TechStack TechStack { get; set; }
    }
    
}
