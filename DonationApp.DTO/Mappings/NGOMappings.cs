using DonationApp.DTO.AppuserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Models.Mappings
{
    public class NGOMappings
    {
        public static NGORegResponseDTO GetNGORegResponseDTO(NGO ngo)
        {
            return new NGORegResponseDTO
            {
                Id = ngo.Id,
                Email = ngo.users.Email,
                NGOName = ngo.NGOName,
                WebsiteLink = ngo.WebsiteLink
              

            };
        }

        public static NGOResponseDTO GetNGOResponseDTO(Appuser ngo)
        {
            return new NGOResponseDTO
            {
                Id = ngo.Id,
                Email = ngo.Email,
               
            };
        }

        public static NGO GetRegNGO(NGORegRequestDTO ngoRegRequestDTO)
        {
            return new NGO
            {
               NGOName = ngoRegRequestDTO.NGOName,
               WebsiteLink = ngoRegRequestDTO.WebsiteLink,
               
               
               
            };
        }
    }
}
