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
        public static DoneeAppResponseDTO GetDoneeRegResponseDTO(Donee donee)
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
                OrgName = donee.OrgName

            };
        }

        public static DoneeResponseDTO GetDoneeResponseDTO(Donee donee)
        {
            return new DoneeResponseDTO
            {
                Country = donee.Country,
                HomeAddress = donee.HomeAddress,
                Id = donee.Id,
                UserId = donee.UserId,
                Gender = donee.Gender.ToString(),
                ItemNeeded = donee.ItemNeeded.ToString(),
                ReasonForApplication = donee.ReasonForApplication.ToString(),
                ImageLink = donee.ImageLink,
                EduLevel = donee.EduLevel.ToString(),
                OrgName = donee.OrgName
            };
        }

        public static Donee GetRegDonee(DoneeAppRequestDTO doneeAppRequestDTO)
        {
            return new Donee
            {
               UserId = doneeAppRequestDTO.UserID,
                DOB  = doneeAppRequestDTO.DOB,
                HomeAddress = doneeAppRequestDTO.HomeAddress,
                Country = doneeAppRequestDTO.Country,
                EduLevel = doneeAppRequestDTO.EduLevel,
                Gender = doneeAppRequestDTO.Gender,
                ItemNeeded= doneeAppRequestDTO.ItemNeeded,
                ImageLink = doneeAppRequestDTO.ImageLink,
                ReasonForApplication = doneeAppRequestDTO.ReasonForApplication,
                LetterOfRecLink = doneeAppRequestDTO.LetterOfRecommendationLink,
                NationalIdLink = doneeAppRequestDTO.NationalIdLink,
                OrgContact = doneeAppRequestDTO.OrgContact,
                OrgName = doneeAppRequestDTO.OrgName,
                OrgWebsite = doneeAppRequestDTO.OrgWebsite,
                Signature = doneeAppRequestDTO.Signature
               





            };
        }
    }
}
