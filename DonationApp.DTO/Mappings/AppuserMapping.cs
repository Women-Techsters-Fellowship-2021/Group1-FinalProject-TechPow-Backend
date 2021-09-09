using DonationApp.DTO.AppuserDTOs;
using DonationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.DTO.Mappings
{
    public class AppuserMapping
    {
        public static UserRegResponseDTO GetUserRegResponseDTO(AppUser user)
        {
            return new UserRegResponseDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                UserName = user.UserName,
                LastName = user.LastName,
                Email = user.Email,
                

            };
        }

        public static UserResponseDTO GetUserResponseDTO(AppUser user)
        {
            return new UserResponseDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                UserName = user.UserName,
                LastName = user.LastName,
                Email = user.Email,
                
            };
        }

        public static AppUser GetRegUser(UserRegRequestDTO userRegRequestDTO)
        {
            return new AppUser
            {
                FirstName = userRegRequestDTO.FirstName,
                LastName = userRegRequestDTO.LastName,
                Email = userRegRequestDTO.Email,
                UserName = string.IsNullOrWhiteSpace(userRegRequestDTO.UserName) ? userRegRequestDTO.Email : userRegRequestDTO.UserName,
               
               
            };
        }
    }
}
