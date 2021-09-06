using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.DTO.UserApplicationDTOs
{
    public class UpdateNGOInfoRequestDTO
    {
        public string LogoImageLink { get; set; }
        public string NGOName { get; set; }
        public string WebsiteLink { get; set; }
    }
}
