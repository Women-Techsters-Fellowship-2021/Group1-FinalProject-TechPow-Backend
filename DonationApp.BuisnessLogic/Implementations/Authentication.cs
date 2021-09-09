using DonationApp.BuisnessLogic.Interfaces;
using DonationApp.DTO.AppuserDTOs;
using DonationApp.DTO.Mappings;
using DonationApp.Models;
using DonationApp.Models.Enums;
using DonationApp.Models.Mappings;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.BuisnessLogic.Implementations
{
    public class Authentication : IAuthentication
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenGenerator _tokenGenerator;
        public Authentication(UserManager<AppUser> userManager, ITokenGenerator tokenGenerator)
        {
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<UserRegResponseDTO> UserRegistrationAsync(UserRegRequestDTO userRegRequestDTO)
        {
            
           var user = AppuserMapping.GetRegUser(userRegRequestDTO);
            IdentityResult result = await _userManager.CreateAsync(user, userRegRequestDTO.Password);
              var assignRole = await _userManager.AddToRoleAsync(user, userRegRequestDTO.TypeofUser);

             if (result.Succeeded && assignRole.Succeeded)
            {
                return AppuserMapping.GetUserRegResponseDTO(user);
            }
            string errors = string.Empty;
            foreach (var error in result.Errors)
            {
                errors += error.Description + Environment.NewLine;
            }
            throw new MissingMemberException(errors);
        }

   
        public async Task<UserResponseDTO> UserLoginAsync(UserLoginRequestDTO userLoginRequestDTO)
        {
            AppUser user = await _userManager.FindByEmailAsync(userLoginRequestDTO.Email);

            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, userLoginRequestDTO.Password))
                {
                    var response = AppuserMapping.GetUserResponseDTO(user);
                    response.Token = await _tokenGenerator.GenerateToken(user);

                    return response;
                }

                throw new AccessViolationException("Invalid Login Credentials");
            }
            throw new AccessViolationException("Invalid Login Credentials");
        }

                
    }
}
