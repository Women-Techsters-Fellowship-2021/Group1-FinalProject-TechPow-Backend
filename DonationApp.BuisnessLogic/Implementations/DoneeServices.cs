using DonationApp.BuisnessLogic.Interfaces;
using DonationApp.DataStore.Interfaces;
using DonationApp.DTO.AppuserDTOs;
using DonationApp.DTO.UserApplicationDTOs;
using DonationApp.Models;
using DonationApp.Models.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.BuisnessLogic.Implementations
{
    public class DoneeServices : IDoneeServices
    {
        private readonly IDoneeAppDatastore _doneeAppDatastore;
        public DoneeServices(IDoneeAppDatastore doneeAppDatastore )
        {
            _doneeAppDatastore = doneeAppDatastore;
        }
        
        public async Task<ServiceResponse<bool>> DeleteDoneeApp(string doneeID, string userId)
        {
            ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>();

            var donee = await GetDoneeApp(doneeID);
            if (donee.Data==null)
            {
                serviceResponse.Message = "Donee application not found";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            if (donee.Data.UserId == userId)
            {
                serviceResponse.Message = "Not Authorrized!";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            var response = await _doneeAppDatastore.DeleteDoneeAppAsync(doneeID, userId);
            if (response)
            {
                serviceResponse.Message = "Donee application deleted successfully..";
                serviceResponse.Success = true;
                return serviceResponse;
            }
            serviceResponse.Message = "Donee application not found";
            serviceResponse.Success = false;
            return serviceResponse;
        }

        public async Task<ServiceResponse<DoneeAppResponseDTO>> DoneeApplicationAsync(DoneeAppRequestDTO doneeAppRequestDTO)
        {
            ServiceResponse<DoneeAppResponseDTO> serviceResponse = new ServiceResponse<DoneeAppResponseDTO>();
           
            DoneeApplication newDonee = new DoneeApplication
            {
                DOB = doneeAppRequestDTO.DOB,
                HomeAddress = doneeAppRequestDTO.HomeAddress,
                UserId = doneeAppRequestDTO.UserID,
                FullName = doneeAppRequestDTO.FullName,
                Country = doneeAppRequestDTO.Country,
                EduLevel = doneeAppRequestDTO.EduLevel,
                Gender = doneeAppRequestDTO.Gender,
                ItemNeeded = doneeAppRequestDTO.ItemNeeded,
                ReasonForApplication = doneeAppRequestDTO.ReasonForApplication,
                ImageLink = doneeAppRequestDTO.ImageLink,
                LetterOfRecLink = doneeAppRequestDTO.LetterOfRecommendationLink,
                NationalIdLink = doneeAppRequestDTO.NationalIdLink,
                OrgName = doneeAppRequestDTO.OrgName,
                OrgContact = doneeAppRequestDTO.OrgContact,
                OrgWebsite = doneeAppRequestDTO.OrgWebsite,
                Signature = doneeAppRequestDTO.Signature,
                PhoneNumber = doneeAppRequestDTO.PhoneNumber
            };

            var newdonee = await _doneeAppDatastore.AddDoneeAppAsync(newDonee);
            if (newdonee != null)
            {
                serviceResponse.Data = DoneeMappings.GetDoneeRegResponseDTO(newdonee);
                serviceResponse.Message = "Application Submitted Successfully...";
                serviceResponse.Success = true;
                return serviceResponse;
            }
            serviceResponse.Message = "Cannot submit application at this time...";
            serviceResponse.Success = false;
            return serviceResponse;
        }

        public async Task<ServiceResponse<DoneeApplication>> GetDoneeApp(string doneeID)
        {
            ServiceResponse<DoneeApplication> serviceResponse = new ServiceResponse<DoneeApplication>();

            var donee = await _doneeAppDatastore.GetDoneeAppAsync(doneeID);
            if(donee !=null)
            {
                serviceResponse.Data = donee;
                serviceResponse.Message = "Donee Application found..";
                serviceResponse.Success = true;
                return serviceResponse;
            }
            serviceResponse.Message = "Donee Application not found..";
            serviceResponse.Success = false;
            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> UpdateDoneeAppByPatch(UpdateDoneeAppRequestDTO updateDoneeAppRequestDTO, string doneeID, string userId)
        {
            ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>();

            var donee = await GetDoneeApp(doneeID);
            if (donee.Data == null)
            {
                serviceResponse.Message = "Donee application not found";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            if (donee.Data.UserId != userId)
            {
                serviceResponse.Message = "Not Authorized!";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            donee.Data.HomeAddress = updateDoneeAppRequestDTO.HomeAddress ?? donee.Data.HomeAddress;
            donee.Data.Country = updateDoneeAppRequestDTO.Country ?? donee.Data.Country;
            donee.Data.ImageLink = updateDoneeAppRequestDTO.ImageLink ?? donee.Data.ImageLink;
            donee.Data.EduLevel = updateDoneeAppRequestDTO.EduLevel ?? donee.Data.EduLevel;
           donee.Data.PhoneNumber = updateDoneeAppRequestDTO.PhoneNumber ?? donee.Data.PhoneNumber;
            var result = await _doneeAppDatastore.UpdateDoneeAppAsync(donee.Data);
            if(result)
            {
                serviceResponse.Message = "Application updated sucessfully..";
                serviceResponse.Success =true;
                return serviceResponse;
            }
            serviceResponse.Message = "Cannot update application at this time..";
            serviceResponse.Success = false;
            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> UpdateDoneeAppStatusByPatch(UpdateDoneeAppRequestDTO updateDoneeAppRequestDTO, string doneeID, string userId)
        {
            ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>();

            var donee = await GetDoneeApp(doneeID);
            if (donee.Data == null)
            {
                serviceResponse.Message = "Donee application not found";
                serviceResponse.Success = false;
                return serviceResponse;
            }
           
            donee.Data.ApplicationStatus = updateDoneeAppRequestDTO.ApplicationStatus ?? donee.Data.ApplicationStatus;

            var result = await _doneeAppDatastore.UpdateDoneeAppStatus(donee.Data);
            if (result)
            {
                serviceResponse.Message = "Application status updated sucessfully..";
                serviceResponse.Success = true;
                return serviceResponse;
            }
            serviceResponse.Message = "Cannot update application status at this time..";
            serviceResponse.Success = false;
            return serviceResponse;
        }


        public async Task<ServiceResponse<bool>> UpdateDoneeAppByPut(UpdateDoneeAppRequestDTO updateDoneeAppRequestDTO, string doneeID, string userId)
        {
            ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>();

            var donee = await GetDoneeApp(doneeID);
            if (donee.Data == null)
            {
                serviceResponse.Message = "Donee application not found";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            if (donee.Data.UserId != userId)
            {
                serviceResponse.Message = "Not Authorized!";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            donee.Data.HomeAddress = updateDoneeAppRequestDTO.HomeAddress;
            donee.Data.Country = updateDoneeAppRequestDTO.Country;
            donee.Data.ImageLink = updateDoneeAppRequestDTO.ImageLink;
            donee.Data.EduLevel = updateDoneeAppRequestDTO.EduLevel;

            var result = await _doneeAppDatastore.UpdateDoneeAppAsync(donee.Data);
            if (result)
            {
                serviceResponse.Message = "Application updated sucessfully..";
                serviceResponse.Success = true;
                return serviceResponse;
            }
            serviceResponse.Message = "Cannot update application at this time..";
            serviceResponse.Success = false;
            return serviceResponse;
        }
    }
}
