using DonationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.DataStore.Interfaces
{
    public interface IDonorFormDatastore
    {
        Task<DonorForm> AddDonorFormAsync(DonorForm donorform);
        Task<DonorForm> GetDonorFormAsync(string donorFormID);
        Task<bool> DeleteDonorFormAsync(string donorFormID, string userId);
        Task<bool> UpdateDonorFormAsync(DonorForm doneeUpdate);

    }
}
