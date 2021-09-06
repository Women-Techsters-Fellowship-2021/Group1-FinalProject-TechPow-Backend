using DonationApp.DTO.AppuserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.BuisnessLogic.Interfaces
{
    public interface IAuthentication
    {
        Task<UserRegResponseDTO>UserRegistrationAsync(UserRegRequestDTO donorRegRequestDTO);
        Task<UserResponseDTO> UserLoginAsync(UserLoginRequestDTO userLoginRequestDTO);
    }
}
