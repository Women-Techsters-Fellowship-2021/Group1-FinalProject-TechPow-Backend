using DonationApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.DTO.UserApplicationDTOs
{
   public class DoneeAppRequestDTO
    {
        [Required]
        public string DOB { get; set; }
        public string UserID { get; set; }
        [Required]
        public string HomeAddress { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string EduLevel { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string ItemNeeded { get; set; }
        [Required]
        public string ReasonForApplication { get; set; }
        [Required]
        public string ImageLink { get; set; }
        [Required]
        public string LetterOfRecommendationLink { get; set; }
        [Required]
        public string NationalIdLink { get; set; }
        [Required]
        public string OrgName { get; set; }
        [Required]
        public string OrgWebsite { get; set; }
        [Required]
        public string OrgContact { get; set; }
        [Required]
        public string Signature { get; set; }




    }
}
