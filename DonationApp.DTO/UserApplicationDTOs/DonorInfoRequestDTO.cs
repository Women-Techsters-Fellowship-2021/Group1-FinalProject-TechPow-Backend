using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.DTO.UserApplicationDTOs
{
    public class DonorInfoRequestDTO
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string HomeAddress { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string ReasonForDonation { get; set; }
        [Required]
        public string DeviceSpecification { get; set; }
        [Required]
        public string ItemOwnership { get; set; }
        [Required]
        public string DeviceCondition { get; set; }
        [Required]
        public string UpdateRequest { get; set; }
        [Required]
        public string Signature { get; set; }

    }
}
