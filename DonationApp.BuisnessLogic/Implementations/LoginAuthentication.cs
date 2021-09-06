using DonationApp.BuisnessLogic.Interfaces;
using DonationApp.DTO.AppuserDTOs;
using DonationApp.Models;
using DonationApp.Models.Mappings;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;


namespace DonationApp.BuisnessLogic.Implementations
{
    public class LoginAuthentication : ILoginAuthentication
    {
        private readonly UserManager<Appuser> _userManager;
        private readonly ITokenGenerator _tokenGenerator;
        public LoginAuthentication(UserManager<Appuser> userManager, ITokenGenerator tokenGenerator)
        {
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
        }


        public async Task<DoneeResponseDTO> DoneeLoginAsync(UserLoginRequestDTO userLoginRequestDTO)
        {
            Appuser user = await _userManager.FindByEmailAsync(userLoginRequestDTO.Email);

            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, userLoginRequestDTO.Password))
                {
                    var response = DoneeMappings.GetDoneeResponseDTO(user);
                    response.Token = await _tokenGenerator.GenerateToken(user);

                    return response;
                }

                throw new AccessViolationException("Invalid Login Credentials");
            }
            throw new AccessViolationException("Invalid Login Credentials");
        }

        public async Task<DonorResponseDTO> DonorLoginAsync(UserLoginRequestDTO userLoginRequestDTO)
        {
            Appuser user = await _userManager.FindByEmailAsync(userLoginRequestDTO.Email);

            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, userLoginRequestDTO.Password))
                {
                    var response = DonorMappings.GetDonorResponseDTO(user);
                    response.Token = await _tokenGenerator.GenerateToken(user);

                    return response;
                }

                throw new AccessViolationException("Invalid Login Credentials");
            }
            throw new AccessViolationException("Invalid Login Credentials");
        }

        public async Task<NGOResponseDTO> NGOLoginAsync(UserLoginRequestDTO userLoginRequestDTO)
        {
            Appuser user = await _userManager.FindByEmailAsync(userLoginRequestDTO.Email);

            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, userLoginRequestDTO.Password))
                {
                    var response = NGOMappings.GetNGOResponseDTO(user);
                    response.Token = await _tokenGenerator.GenerateToken(user);

                    return response;
                }

                throw new AccessViolationException("Invalid Login Credentials");
            }
            throw new AccessViolationException("Invalid Login Credentials");
        }
    }
}
