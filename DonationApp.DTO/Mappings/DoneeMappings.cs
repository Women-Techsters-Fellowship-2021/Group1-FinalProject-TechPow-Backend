using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonationApp.DTO.AppuserDTOs;

namespace DonationApp.Models.Mappings
{
   public class DoneeMappings
    {
        public static DoneeRegResponseDTO GetDoneeRegResponseDTO(Appuser donee)
        {
            return new DoneeRegResponseDTO
            {
                Id = donee.Id,
                FirstName = donee.FirstName,
                UserName = donee.UserName,
                LastName = donee.LastName,
                Email = donee.Email,
                PhoneNumber = donee.PhoneNumber
               
            };
        }

        public static DoneeResponseDTO GetDoneeResponseDTO(Appuser donee)
        {
            return new DoneeResponseDTO
            {
                Id = donee.Id,
                FirstName = donee.FirstName,
                UserName = donee.UserName,
                LastName = donee.LastName,
                Email = donee.Email,
                PhoneNumber = donee.PhoneNumber
            };
        }

        public static Appuser GetRegDonee(DoneeRegRequestDTO doneeRegRequestDTO)
        {
            return new Appuser
            {
                FirstName = doneeRegRequestDTO.FirstName,
                LastName = doneeRegRequestDTO.LastName,
                Email = doneeRegRequestDTO.Email,
                PhoneNumber = doneeRegRequestDTO.PhoneNumber,
                UserName = string.IsNullOrWhiteSpace(doneeRegRequestDTO.UserName) ? doneeRegRequestDTO.Email : doneeRegRequestDTO.UserName,
                Roles = Enums.Roles.Donee
            };
        }
    }
}
