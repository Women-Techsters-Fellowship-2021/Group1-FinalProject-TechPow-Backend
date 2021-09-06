using DonationApp.DTO.AppuserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Models.Mappings
{
   public class DonorMappings
    {

        public static DonorRegResponseDTO GetDonorRegResponseDTO(Appuser donor)
        {
            return new DonorRegResponseDTO
            {
                Id = donor.Id,
                FirstName = donor.FirstName,
                UserName = donor.UserName,
                LastName = donor.LastName,
                Email = donor.Email,
                
            };
        }

        public static DonorResponseDTO GetDonorResponseDTO(Appuser appuser)
        {
            return new DonorResponseDTO
            {
                Id = appuser.Id,
                FirstName = appuser.FirstName,
                LastName = appuser.LastName,
                Email = appuser.Email,
               
            };
        }

        public static Appuser GetRegDonor(DonorRegRequestDTO donorRegRequestDTO)
        {
            return new Appuser
            {
                FirstName = donorRegRequestDTO.FirstName,
                LastName = donorRegRequestDTO.LastName,
                Email = donorRegRequestDTO.Email,
                UserName = string.IsNullOrWhiteSpace(donorRegRequestDTO.UserName) ? donorRegRequestDTO.Email : donorRegRequestDTO.UserName,
                Roles = Enums.Roles.Donor
            };
        }
    }
}
