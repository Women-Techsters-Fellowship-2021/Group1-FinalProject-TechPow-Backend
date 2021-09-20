using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonationApp.DTO.AppuserDTOs;
using DonationApp.DTO.UserApplicationDTOs;

namespace DonationApp.Models.Mappings
{
    public class DoneeMappings
    {
        public static DoneeAppResponseDTO GetDoneeRegResponseDTO(DoneeApplication donee)
        {
            return new DoneeAppResponseDTO
            {
                Id = donee.Id,
                UserId = donee.UserId,
                Gender = donee.Gender.ToString(),
                ItemNeeded = donee.ItemNeeded.ToString(),
                ReasonForApplication = donee.ReasonForApplication.ToString(),
                ImageLink = donee.ImageLink,
                EduLevel = donee.EduLevel.ToString(),
                OrgName = donee.OrgName,
                ApplicationStatus = donee.ApplicationStatus
            };
        }

        public static DoneeResponseDTO GetDoneeResponseDTO(DoneeApplication donee)
        {
            return new DoneeResponseDTO
            {

                Id = donee.Id,
                UserId = donee.UserId,
                FirstName = donee.FirstName,
                LastName = donee.LastName,
                Gender = donee.Gender.ToString(),
                Country = donee.Country,
                HomeAddress = donee.HomeAddress,
                ItemNeeded = donee.ItemNeeded.ToString(),
                ReasonForApplication = donee.ReasonForApplication.ToString(),
                ImageLink = donee.ImageLink,
                EduLevel = donee.EduLevel.ToString(),
                OrgName = donee.OrgName,
                ApplicationStatus = donee.ApplicationStatus,
                PhoneNumber = donee.PhoneNumber
            };
        }

        public static DoneeApplication GetRegDonee(DoneeAppRequestDTO doneeAppRequestDTO)
        {
            return new DoneeApplication
            {
                UserId = doneeAppRequestDTO.UserID,
                FirstName = doneeAppRequestDTO.FirstName,
                LastName = doneeAppRequestDTO.LastName,
                DOB = doneeAppRequestDTO.DOB,
                HomeAddress = doneeAppRequestDTO.HomeAddress,
                Country = doneeAppRequestDTO.Country,
                EduLevel = doneeAppRequestDTO.EduLevel,
                Gender = doneeAppRequestDTO.Gender,
                ItemNeeded = doneeAppRequestDTO.ItemNeeded,
                ImageLink = doneeAppRequestDTO.ImageLink,
                ReasonForApplication = doneeAppRequestDTO.ReasonForApplication,
                LetterOfRecLink = doneeAppRequestDTO.LetterOfRecommendationLink,
                NationalIdLink = doneeAppRequestDTO.NationalIdLink,
                OrgContact = doneeAppRequestDTO.OrgContact,
                OrgName = doneeAppRequestDTO.OrgName,
                OrgWebsite = doneeAppRequestDTO.OrgWebsite,
                Signature = doneeAppRequestDTO.Signature,
                ApplicationStatus = doneeAppRequestDTO.ApplicationStatus,
                PhoneNumber = doneeAppRequestDTO.PhoneNumber
            };
        }
    }
}
