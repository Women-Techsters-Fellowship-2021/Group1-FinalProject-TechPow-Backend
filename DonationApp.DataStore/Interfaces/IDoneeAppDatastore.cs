using DonationApp.DTO.UserApplicationDTOs;
using DonationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace DonationApp.DataStore.Interfaces
{
    public interface IDoneeAppDatastore
    {
        Task<DoneeApplication> AddDoneeAppAsync(DoneeApplication donee);
        Task<DoneeApplication> GetDoneeAppAsync(string doneeID);
        Task<bool> DeleteDoneeAppAsync(string DoneeID);
        Task<bool> UpdateDoneeAppAsync(DoneeApplication doneeUpdate);
        Task<bool> UpdateDoneeAppStatus(DoneeApplication doneeAppStatusUpdate);
        Task<List<DoneeApplication>> GetAllDoneeAppAsync();

    }
}
