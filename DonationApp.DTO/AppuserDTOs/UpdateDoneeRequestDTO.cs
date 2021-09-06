using DonationApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.DTO.AppuserDTOs
{
    public class UpdateDoneeRequestDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public CareerStatus CareerStatus { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string ShortBio { get; set; }
    }
}
