using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.DTO.EmailDTO
{
    public class EmailRequestDTO
    {
        [Required]
        public string ToEmail { get; set; }
        //public string FromEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
