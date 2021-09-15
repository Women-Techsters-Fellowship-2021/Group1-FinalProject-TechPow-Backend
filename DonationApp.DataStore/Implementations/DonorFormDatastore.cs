using DonationApp.DataStore.Interfaces;
using DonationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.DataStore.Implementations
{
    public class DonorFormDatastore : IDonorFormDatastore
    {
        public Task<DonorForm> AddDonorFormAsync(DonorForm donorform)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDonorFormAsync(string donorFormID, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<DonorForm> GetDonorFormAsync(string donorFormID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDonorFormAsync(DonorForm doneeUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
