using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.DTO.UserApplicationDTOs
{
    public class UpdateDonorInfoRequest
    {
        public string ReasonForDonation { get; set; }
        public string DeviceSpecification { get; set; }
        public string ItemOwnership { get; set; }
        public string DeviceCondition { get; set; }
        public string Signature { get; set; }
    }
}
