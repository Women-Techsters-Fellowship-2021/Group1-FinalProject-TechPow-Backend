﻿using DonationApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.DTO.UserApplicationDTOs
{
    public class DoneeResponseDTO
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string DOB { get; set; }
        public string HomeAddress { get; set; }
        public string Country { get; set; }
        public string EduLevel { get; set; }
        public string Gender { get; set; }
        public string ItemNeeded { get; set; }
        public string ReasonForApplication { get; set; }
        public string ImageLink { get; set; }
        public string LetterOfRecLink { get; set; }
        public string NationalIdLink { get; set; }
        public string OrgName { get; set; }
        public string OrgWebsite { get; set; }
        public string OrgContact { get; set; }
        public string Signature { get; set; }
    }
}
