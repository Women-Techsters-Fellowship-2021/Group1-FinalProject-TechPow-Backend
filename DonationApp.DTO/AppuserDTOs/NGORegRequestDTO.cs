using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.DTO.AppuserDTOs
{
   public class NGORegRequestDTO
    {
         public string NGOName { get; set; }
         public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LogoImageLink { get; set; }
        public string WebsiteLink { get; set; }
    }
}
