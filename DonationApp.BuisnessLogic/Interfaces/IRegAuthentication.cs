using DonationApp.DTO.AppuserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.BuisnessLogic.Interfaces
{
    public interface IRegAuthentication
    {
        Task<DonorRegResponseDTO> DonorRegistrationAsync(DonorRegRequestDTO donorRegRequestDTO);
        Task<DoneeRegResponseDTO> DoneeRegistrationAsync(DoneeRegRequestDTO doneeRegRequestDTO);
        Task<NGORegResponseDTO> NGORegistrationAsync(NGORegRequestDTO ngoRegRequestDTO);
    }
}
