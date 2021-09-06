using DonationApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.DTO.UserApplicationDTOs
{
   public class DoneeAppResponseDTO
    {
        public string Id { get; set; }
        public string ItemNeeded { get; set; }
        public CareerStatus CareerStatus { get; set; }
        public string ShortBio { get; set; }
        public string PhoneNumber { get; set; }
       
    }
}
