using DonationApp.DTO.AppuserDTOs;
using DonationApp.DTO.UserApplicationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.Models.Mappings
{
   public class DonorMappings
    {

        //public static DonorInfoResponseDTO GetDonorInfoResponseDTO(DonorForm donor)
        //{
        //    return new DonorInfoResponseDTO
        //    {
             
        //    };
        //}

        public static DonorResponseDTO GetDonorResponseDTO(DonorForm donorForm)
        {
            return new DonorResponseDTO
            {
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

        public static DonorForm GetRegDonorForm(DonorInfoRequestDTO donorinfoRequestDTO)
        {
            return new DonorForm
            { 
                FullName = donorinfoRequestDTO.FullName,
                PhoneNumber = donorinfoRequestDTO.PhoneNumber,
                HomeAddress = donorinfoRequestDTO.HomeAddress,
                Country = donorinfoRequestDTO.Country,
                ReasonForDonation = donorinfoRequestDTO.ReasonForDonation,
                DeviceCondition = donorinfoRequestDTO.DeviceCondition,
                ItemOwnership = donorinfoRequestDTO.ItemOwnership,
                DeviceSpecification = donorinfoRequestDTO.DeviceSpecification,
                UpdateRequest = donorinfoRequestDTO.UpdateRequest,
                Signature = donorinfoRequestDTO.Signature
            };
                
        }
    }
}
