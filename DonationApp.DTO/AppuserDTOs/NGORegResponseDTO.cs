using DonationApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.DTO.AppuserDTOs
{
   public class NGORegResponseDTO
    {
        public string Id { get; set; }
        public string NGOName { get; set; }
        public string WebsiteLink { get; set; }
        public string Email { get; set; }
         public string Password { get; set; }
         public Roles Roles { get; set; }
    }
}
