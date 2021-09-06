using DonationApp.DTO.AppuserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.BuisnessLogic.Interfaces
{
    public interface ILoginAuthentication
    {
        Task<DonorResponseDTO> DonorLoginAsync(UserLoginRequestDTO userLoginRequestDTO);
        Task<DoneeResponseDTO> DoneeLoginAsync(UserLoginRequestDTO userLoginRequestDTO);
        Task<NGOResponseDTO> NGOLoginAsync(UserLoginRequestDTO userLoginRequestDTO);
    }
}

