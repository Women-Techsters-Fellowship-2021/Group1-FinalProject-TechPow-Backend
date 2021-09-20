using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonationApp.BuisnessLogic.Interfaces;
using DonationApp.DataStore.Interfaces;
using DonationApp.DTO.AppuserDTOs;
using DonationApp.DTO.UserApplicationDTOs;
using DonationApp.Models;
using DonationApp.Models.Mappings;

namespace DonationApp.BuisnessLogic.Implementations
{
    public class DonorServices : IDonorServices
    {
        private readonly IDonorFormDatastore _donorFormDatastore;
        public DonorServices(IDonorFormDatastore donorFormDatastore )
        {
            _donorFormDatastore = donorFormDatastore ?? throw new ArgumentNullException(nameof(donorFormDatastore));
        }
        
        public async Task<ServiceResponse<bool>> DeleteDonorForm(string donorFormID)
        {
            ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>();

            var donor = await GetDonorForm(donorFormID);
            if (donor.Data==null)
            {
                serviceResponse.Message = "Donor application not found";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            //if (donor.Data.UserId == userId)
            //{
            //    serviceResponse.Message = "Not Authorrized!";
            //    serviceResponse.Success = false;
            //    return serviceResponse;
            //}
            var response = await _donorFormDatastore.DeleteDonorFormAsync(donorFormID);
            if (response)
            {
                serviceResponse.Message = "Donor application deleted successfully..";
                serviceResponse.Success = true;
                return serviceResponse;
            }
            serviceResponse.Message = "Donor application not found";
            serviceResponse.Success = false;
            return serviceResponse;
        }

        public async Task<ServiceResponse<DonorResponseDTO>> DonorFormAsync(DonorInfoRequestDTO donorInfoRequestDTO)
        {
            ServiceResponse<DonorResponseDTO> serviceResponse = new ServiceResponse<DonorResponseDTO>();

            DonorForm newDonor = new DonorForm
            {
                UserId = donorInfoRequestDTO.UserId,
                FirstName = donorInfoRequestDTO.FirstName,
            LastName = donorInfoRequestDTO.LastName,
                PhoneNumber = donorInfoRequestDTO.PhoneNumber,
                HomeAddress = donorInfoRequestDTO.HomeAddress,
                Country = donorInfoRequestDTO.Country,
                ReasonForDonation = donorInfoRequestDTO.ReasonForDonation,
                DeviceSpecification = donorInfoRequestDTO.DeviceSpecification,
                ItemOwnership = donorInfoRequestDTO.ItemOwnership,
                DeviceCondition = donorInfoRequestDTO.DeviceCondition,
                UpdateRequest = donorInfoRequestDTO.UpdateRequest,
                Signature = donorInfoRequestDTO.Signature
            };

            var newdonor = await _donorFormDatastore.AddDonorFormAsync(newDonor);

            if (newdonor != null)
            {
                serviceResponse.Data = DonorMappings.GetDonorResponseDTO(newdonor);
                serviceResponse.Message = "Donation submitted Successfully...";
                serviceResponse.Success = true;
                return serviceResponse;
            }
            serviceResponse.Message = "Cannot process donation at this time...";
            serviceResponse.Success = false;
            return serviceResponse;
        }

        public async Task<ServiceResponse<DonorForm>> GetDonorForm(string donorFormID)
        {
            ServiceResponse<DonorForm> serviceResponse = new ServiceResponse<DonorForm>();

            var donor = await _donorFormDatastore.GetDonorFormAsync(donorFormID);
            if(donor !=null)
            {
                serviceResponse.Data = donor;
                serviceResponse.Message = "Donor Application found..";
                serviceResponse.Success = true;
                return serviceResponse;
            }
            serviceResponse.Message = "Donor Application not found..";
            serviceResponse.Success = false;
            return serviceResponse;
        }

     

        public async Task<ServiceResponse<bool>> UpdateDonorFormByPatch(UpdateDonorInfoRequest updateDonorInfoRequest, string donorFormID, string userId)
        {
            ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>();

            var donor = await GetDonorForm(donorFormID);
            if (donor.Data == null)
            {
                serviceResponse.Message = "Donor application not found";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            if (donor.Data.UserId != userId)
            {
                serviceResponse.Message = "Not Authorized!";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            donor.Data.ReasonForDonation = updateDonorInfoRequest.ReasonForDonation ?? donor.Data.ReasonForDonation;
            donor.Data.DeviceSpecification = updateDonorInfoRequest.DeviceSpecification ?? donor.Data.DeviceSpecification;
            donor.Data.ItemOwnership = updateDonorInfoRequest.ItemOwnership ?? donor.Data.ItemOwnership;
            donor.Data.DeviceCondition = updateDonorInfoRequest.DeviceCondition ?? donor.Data.DeviceCondition;
            //donor.Data.Signature = updateDonorInfoRequest.Signature ?? donor.Data.Signature;
           
            var result = await _donorFormDatastore.UpdateDonorFormAsync(donor.Data);
            if(result)
            {
                serviceResponse.Message = "Donation details updated sucessfully..";
                serviceResponse.Success =true;
                return serviceResponse;
            }
            serviceResponse.Message = "Cannot update donation details at this time..";
            serviceResponse.Success = false;
            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> UpdateDonorFormByPut(UpdateDonorInfoRequest updateDonorInfoRequest, string donorFormID, string userId)
        {
            ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>();

             var donor = await GetDonorForm(donorFormID);
            if (donor.Data == null)
            {
                serviceResponse.Message = "Donor application not found";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            if (donor.Data.UserId != userId)
            {
                serviceResponse.Message = "Not Authorized!";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            donor.Data.ReasonForDonation = updateDonorInfoRequest.ReasonForDonation;
            donor.Data.DeviceSpecification = updateDonorInfoRequest.DeviceSpecification;
            donor.Data.ItemOwnership = updateDonorInfoRequest.ItemOwnership;
            donor.Data.DeviceCondition = updateDonorInfoRequest.DeviceCondition;

            var result = await _donorFormDatastore.UpdateDonorFormAsync(donor.Data);
            if (result)
            {
                serviceResponse.Message = "Donation details updated sucessfully..";
                serviceResponse.Success = true;
                return serviceResponse;
            }
            serviceResponse.Message = "Cannot update donation details at this time..";
            serviceResponse.Success = false;
            return serviceResponse;
        }
    }
}
