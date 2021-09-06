using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.DTO.AppuserDTOs
{
    public class NGOResponseDTO
    {
        public string Id { get; set; }
      //  public string LogoImageLink { get; set; }
        public string NGOName { get; set; }
        public string WebsiteLink { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
