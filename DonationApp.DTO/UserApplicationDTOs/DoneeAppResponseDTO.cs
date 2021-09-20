using DonationApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.DTO.UserApplicationDTOs
{
   public class DoneeAppResponseDTO
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeAddress { get; set; }
        public string Country { get; set; }
        public string EduLevel { get; set; }
        public string Gender { get; set; }
        public string ItemNeeded { get; set; }
        public string ReasonForApplication { get; set; }
        public string ImageLink { get; set; }
        public string OrgName { get; set; }
        public string ApplicationStatus { get; set; }





    }
}
