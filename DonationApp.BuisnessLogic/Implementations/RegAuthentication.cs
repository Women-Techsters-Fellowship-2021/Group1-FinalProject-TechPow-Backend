using DonationApp.BuisnessLogic.Interfaces;
using DonationApp.DTO.AppuserDTOs;
using DonationApp.Models;
using DonationApp.Models.Enums;
using DonationApp.Models.Mappings;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.BuisnessLogic.Implementations
{
    public class RegAuthentication : IRegAuthentication
    {
        private readonly UserManager<Appuser> _userManager;
        private readonly ITokenGenerator _tokenGenerator;
        public RegAuthentication(UserManager<Appuser> userManager, ITokenGenerator tokenGenerator)
        {
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<DoneeRegResponseDTO> DoneeRegistrationAsync(DoneeRegRequestDTO doneeRegRequestDTO)
        {
            var userDonee = DoneeMappings.GetRegDonee(doneeRegRequestDTO);
            IdentityResult result = await _userManager.CreateAsync(userDonee, doneeRegRequestDTO.Password);
            var assignRole = await _userManager.AddToRoleAsync(userDonee, Roles.Donee.ToString());

            if (result.Succeeded && assignRole.Succeeded)
            {
                return DoneeMappings.GetDoneeRegResponseDTO(userDonee);
            }
            string errors = string.Empty;
            foreach (var error in result.Errors)
            {
                errors += error.Description + Environment.NewLine;
            }
            throw new MissingFieldException(errors);
        }

       public async Task<DonorRegResponseDTO> DonorRegistrationAsync(DonorRegRequestDTO donorRegRequestDTO)
        {
            var userDonor = DonorMappings.GetRegDonor(donorRegRequestDTO);
            IdentityResult result = await _userManager.CreateAsync(userDonor, donorRegRequestDTO.Password);
            var assignRole = await _userManager.AddToRoleAsync(userDonor, Roles.Donor.ToString());

            if (result.Succeeded && assignRole.Succeeded)
            {
                return DonorMappings.GetDonorRegResponseDTO(userDonor);
            }
            string errors = string.Empty;
            foreach (var error in result.Errors)
            {
                errors += error.Description + Environment.NewLine;
            }
            throw new MissingFieldException(errors);
        }

      

        public async Task<NGORegResponseDTO> NGORegistrationAsync(NGORegRequestDTO ngoRegRequestDTO)
        {
            var userNGO = NGOMappings.GetRegNGO(ngoRegRequestDTO);
            IdentityResult result = await _userManager.CreateAsync(userNGO.users, ngoRegRequestDTO.Password);
            var assignRole = await _userManager.AddToRoleAsync(userNGO.users, Roles.NGO.ToString());

            if (result.Succeeded && assignRole.Succeeded)
            {
                return NGOMappings.GetNGORegResponseDTO(userNGO);
            }
            string errors = string.Empty;
            foreach (var error in result.Errors)
            {
                errors += error.Description + Environment.NewLine;
            }
            throw new MissingFieldException(errors);
        }

        
    }
}
