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
        Task<bool> DeleteDoneeAppAsync(string DoneeID, string userId);
        Task<bool> UpdateDoneeAppAsync(DoneeApplication doneeUpdate);
        Task<bool> UpdateDoneeAppStatus(DoneeApplication doneeAppStatusUpdate);
    }
}
