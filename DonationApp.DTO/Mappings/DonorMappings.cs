using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonationApp.DTO.AppuserDTOs;
using DonationApp.DTO.UserApplicationDTOs;

namespace DonationApp.Models.Mappings
{
   public class DonorMappings
    {

        public static DonorInfoResponseDTO GetDonorInfoResponseDTO(DonorForm donor)
        {
           return new DonorInfoResponseDTO
           {
             Id = donor.Id,
             UserId = donor.UserId,
             FullName = donor.FullName,
             Country  = donor.Country,
             ReasonForDonation = donor.ReasonForDonation,
             DeviceSpecification = donor.DeviceSpecification,
           };
        }

        public static DonorResponseDTO GetDonorResponseDTO(DonorForm donorForm)
        {
            return new DonorResponseDTO
            {
             Id = donorForm.Id,
             UserId = donorForm.UserId,
             FullName = donorForm.FullName,
             PhoneNumber = donorForm.PhoneNumber,
             HomeAddress = donorForm.HomeAddress,
             Country  = donorForm.Country,
             ReasonForDonation = donorForm.ReasonForDonation,
             DeviceCondition = donorForm.ReasonForDonation,
             ItemOwnership = donorForm.ItemOwnership,
             DeviceSpecification = donorForm.DeviceSpecification,
             UpdateRequest = donorForm.UpdateRequest,
             Signature = donorForm.Signature
            };
        }

        public static DonorForm GetRegDonorForm(DonorInfoRequestDTO donorInfoRequestDTO)
        {
            return new DonorForm
            { 
                UserId = donorInfoRequestDTO.UserId,
                FullName = donorInfoRequestDTO.FullName,
                PhoneNumber = donorInfoRequestDTO.PhoneNumber,
                HomeAddress = donorInfoRequestDTO.HomeAddress,
                Country = donorInfoRequestDTO.Country,
                ReasonForDonation = donorInfoRequestDTO.ReasonForDonation,
                DeviceCondition = donorInfoRequestDTO.DeviceCondition,
                ItemOwnership = donorInfoRequestDTO.ItemOwnership,
                DeviceSpecification = donorInfoRequestDTO.DeviceSpecification,
                UpdateRequest = donorInfoRequestDTO.UpdateRequest,
                Signature = donorInfoRequestDTO.Signature
            };
                
        }
    }
}
