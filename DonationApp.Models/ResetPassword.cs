using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DonationApp.Models
{
   public class ResetPassword
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string OTP { get; set; }
        public DateTime InsertDateTimeUTC { get; set; }

        //Navigation properties
        public AppUser User { get; set; }

    }
}
