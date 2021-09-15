﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.DTO.UserApplicationDTOs
{
   public class DonorInfoResponseDTO
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeAddress { get; set; }
        public string Country { get; set; }
        public string ReasonForDonation { get; set; }
        public string DeviceSpecification { get; set; }
 
    }

}
