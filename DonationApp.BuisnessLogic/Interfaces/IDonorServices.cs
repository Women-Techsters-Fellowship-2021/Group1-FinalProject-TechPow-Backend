using DonationApp.DTO.UserApplicationDTOs;
using DonationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.BuisnessLogic.Interfaces
{
    public interface IDonorServices
    {
        Task<ServiceResponse<DonorResponseDTO>> DonorFormAsync(DonorInfoRequestDTO donorInfoRequestDTO);
        Task<ServiceResponse<bool>> UpdateDonorFormByPut(UpdateDonorInfoRequest updateDonorInfoRequest, string donorInfoID, string userId);
        Task<ServiceResponse<bool>> UpdateDonorFormByPatch(UpdateDonorInfoRequest updateDonorInfoRequest, string donorInfoID, string userId);
        Task<ServiceResponse<bool>> DeleteDonorForm(string donorFormID, string userId);
        Task<ServiceResponse<DoneeApplication>> GetDonorForm(string donorFormID);
    }
}
