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

        public async Task<ServiceResponse<UserRegResponseDTO>> UserRegistrationAsync(UserRegRequestDTO userRegRequestDTO)
        {
            ServiceResponse<UserRegResponseDTO> serviceResponse = new ServiceResponse<UserRegResponseDTO>();

            var user = AppuserMapping.GetRegUser(userRegRequestDTO);
            IdentityResult result = await _userManager.CreateAsync(user, userRegRequestDTO.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, userRegRequestDTO.TypeofUser);
                serviceResponse.Data = AppuserMapping.GetUserRegResponseDTO(user);
                serviceResponse.Message = "User Registered Successfully. Please Login to continue..";
                serviceResponse.Success = true;
                return serviceResponse;
            }

           
            foreach (var error in result.Errors)
            {
                serviceResponse.Errors.Add(error.Description);
            }
            serviceResponse.Message = "User Registration failed";
            serviceResponse.Success = false;
            return serviceResponse;


        }

        public async Task<ServiceResponse<UserResponseDTO>> UserLoginAsync(UserLoginRequestDTO userLoginRequestDTO)

        {
            ServiceResponse<UserResponseDTO> serviceResponse = new ServiceResponse<UserResponseDTO>();

            AppUser user = await _userManager.FindByEmailAsync(userLoginRequestDTO.Email);

            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, userLoginRequestDTO.Password))
                {
                                       
                    IList<string> roles = await _userManager.GetRolesAsync(user);
                    serviceResponse.Data = AppuserMapping.GetUserResponseDTO(user);
                     serviceResponse.Data.Token = await _tokenGenerator.GenerateToken(user);
                      serviceResponse.Data.TypeofUser = roles.FirstOrDefault();
                    serviceResponse.Message = "User login Successfully..";
                    serviceResponse.Success = true;
                     return serviceResponse;
                }
                 serviceResponse.Message = "Invalid login credientials...";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            serviceResponse.Message = "Account for this user not found..";
            serviceResponse.Success = false;
            return serviceResponse;
        }


    }
}
