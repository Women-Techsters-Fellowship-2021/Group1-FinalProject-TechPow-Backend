using DonationApp.DTO.AppuserDTOs;
using DonationApp.DTO.UserApplicationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Models.Mappings
{
   public class DonorMappings
    {

        public static DonorInfoResponseDTO GetDonorInfoResponseDTO(Donor donor)
        {
            return new DonorInfoResponseDTO
            {
             
            };
        }

        public static DonorResponseDTO GetDonorResponseDTO(Donor donor)
        {
            return new DonorResponseDTO
            {
             
            };
        }

        public static Donor GetRegDonor(DonorInfoRequestDTO donorinfoRequestDTO)
        {
            return new Donor
            { 
            };
                
        }
    }
}
