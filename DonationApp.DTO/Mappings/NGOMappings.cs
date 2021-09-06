using DonationApp.DTO.AppuserDTOs;
using DonationApp.DTO.UserApplicationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Models.Mappings
{
    public class NGOMappings
    {
        public static NGOInfoResponseDTO GetNGOInfoResponseDTO(NGO ngo)
        {
            return new NGOInfoResponseDTO
            {
                Id = ngo.Id,
                Email = ngo.users.Email,
                NGOName = ngo.NGOName,
                WebsiteLink = ngo.WebsiteLink
              
            };
        }

        public static NGOResponseDTO GetNGOResponseDTO(NGO ngo)
        {
            return new NGOResponseDTO
            {
                Id = ngo.Id,
                Email = ngo.users.Email,
                WebsiteLink = ngo.WebsiteLink
               
            };
        }

        public static NGO GetRegNGO(NGOInfoRequestDTO ngoInfoRequestDTO)
        {
            return new NGO
            {
                
               NGOName = ngoInfoRequestDTO.NGOName,
               WebsiteLink = ngoInfoRequestDTO.WebsiteLink,
               
               
               
            };
        }
    }
}
