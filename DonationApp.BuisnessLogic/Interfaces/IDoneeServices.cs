using DonationApp.DTO.AppuserDTOs;
using DonationApp.DTO.UserApplicationDTOs;
using DonationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace DonationApp.BuisnessLogic.Interfaces
{
    public interface IDoneeServices
    {
        Task<ServiceResponse<DoneeAppResponseDTO>> DoneeApplicationAsync(DoneeAppRequestDTO doneeAppRequestDTO);
        Task<ServiceResponse<bool>> UpdateDoneeAppByPut(UpdateDoneeAppRequestDTO updateDoneeAppRequestDTO, string doneeID, string userId);
        Task<ServiceResponse<bool>> UpdateDoneeAppByPatch(UpdateDoneeAppRequestDTO updateDoneeAppRequestDTO, string doneeID, string userId);
        Task<ServiceResponse<bool>> UpdateDoneeAppStatusByPatch(UpdateDoneeAppRequestDTO updateDoneeAppRequestDTO, string doneeID, string userId);
        Task<ServiceResponse<bool>> DeleteDoneeApp(string doneeID);
        Task<ServiceResponse<DoneeApplication>> GetDoneeApp(string doneeID);
        Task<ServiceResponse<List<DoneeApplication>>> GetAllDoneeApplications();

    }
}
