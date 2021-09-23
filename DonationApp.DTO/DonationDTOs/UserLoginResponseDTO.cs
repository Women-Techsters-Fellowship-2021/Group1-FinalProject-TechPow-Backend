using DonationApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.DTO.AppuserDTOs
{
    public class UserLoginResponseDTO
    {
        public string Id { get; set; }
          public string Email { get; set; }
        public string TypeofUser { get; set; }
        public string Token { get; set; }
    }
}
