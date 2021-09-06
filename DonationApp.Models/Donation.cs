using DonationApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Models
{
   public class Donation
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string DonorId { get; set; }
        public string DoneeId { get; set; }
        public DateTime DonationDate  { get; set; }
        public DonationStatus DonationStatus { get; set; }


}
    
}
