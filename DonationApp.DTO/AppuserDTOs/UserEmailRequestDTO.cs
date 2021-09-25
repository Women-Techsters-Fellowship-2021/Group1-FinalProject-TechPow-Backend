using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.DTO.AppuserDTOs
{
    public class UserEmailRequestDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
