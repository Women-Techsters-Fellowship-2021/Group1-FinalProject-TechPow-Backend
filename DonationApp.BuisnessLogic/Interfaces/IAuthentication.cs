using DonationApp.DTO.AppuserDTOs;
using DonationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.BuisnessLogic.Interfaces
{
    public interface IAuthentication
    {
        Task<ServiceResponse<UserRegResponseDTO>> UserRegistrationAsync(UserRegRequestDTO donorRegRequestDTO);
        Task<ServiceResponse<UserResponseDTO>> UserLoginAsync(UserLoginRequestDTO userLoginRequestDTO);
    }
}
