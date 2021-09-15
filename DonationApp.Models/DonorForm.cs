using DonationApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Models
{
    public class DonorForm
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeAddress { get; set; }
        public string Country { get; set; }
        public string ReasonForDonation { get; set; }
        public string DeviceSpecification { get; set; }
        public string ItemOwnership { get; set; }
        public string DeviceCondition { get; set; }
        public string UpdateRequest { get; set; }
        public string Signature { get; set; }
        
        //Navigation properties
        public AppUser user { get; set; }
    }
}
