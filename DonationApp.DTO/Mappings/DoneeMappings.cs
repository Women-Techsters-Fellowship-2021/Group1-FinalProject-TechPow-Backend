using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonationApp.DTO.AppuserDTOs;
using DonationApp.DTO.UserApplicationDTOs;

namespace DonationApp.Models.Mappings
{
   public class DoneeMappings
    {
        public static DoneeAppResponseDTO GetDoneeRegResponseDTO(Donee donee)
        {
            return new DoneeAppResponseDTO
            {
                
               
            };
        }

        public static DoneeResponseDTO GetDoneeResponseDTO(Donee donee)
        {
            return new DoneeResponseDTO
            {
                
            };
        }

        public static Donee GetRegDonee(DoneeAppRequestDTO doneeAppRequestDTO)
        {
            return new Donee
            {
                
                
            };
        }
    }
}
