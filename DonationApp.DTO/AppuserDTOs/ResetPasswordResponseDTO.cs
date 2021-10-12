using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.DTO.AppuserDTOs
{
   public class ResetPasswordResponseDTO
    {
        public string Email { get; set; }
       
        public int OTP { get; set; }
       
        public string NewPassword { get; set; }
    }
}
