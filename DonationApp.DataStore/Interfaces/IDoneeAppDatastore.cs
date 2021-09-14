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
        Task<Donee> AddDoneeAppAsync(Donee donee);
        Task<Donee> GetDoneeAppAsync(string doneeID);
        Task<bool> DeleteDoneeAppAsync(string DoneeID, string userId);
        Task<bool> UpdateDoneeAppAsync(Donee doneeUpdate);
    }
}
