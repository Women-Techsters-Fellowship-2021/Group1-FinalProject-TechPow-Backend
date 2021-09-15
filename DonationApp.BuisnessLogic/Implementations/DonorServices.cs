using DonationApp.BuisnessLogic.Interfaces;
using DonationApp.DTO.UserApplicationDTOs;
using DonationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.BuisnessLogic.Implementations
{
    public class DonorServices : IDonorServices
    {
        public Task<ServiceResponse<bool>> DeleteDonorForm(string donorFormID, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<DonorResponseDTO>> DonorFormAsync(DonorInfoRequestDTO donorInfoRequestDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<DoneeApplication>> GetDonorForm(string donorFormID)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> UpdateDonorFormByPatch(UpdateDonorInfoRequest updateDonorInfoRequest, string donorInfoID, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> UpdateDonorFormByPut(UpdateDonorInfoRequest updateDonorInfoRequest, string donorInfoID, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
