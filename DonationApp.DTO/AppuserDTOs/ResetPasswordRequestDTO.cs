using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.DTO.AppuserDTOs
{
    public class ResetPasswordRequestDTO
    {
        [Required]
        public string Email  { get; set; }
        [Required]
        public int  OTP { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
