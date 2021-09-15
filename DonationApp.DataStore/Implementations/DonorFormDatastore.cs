using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonationApp.DataStore.Interfaces;
using DonationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DonationApp.DataStore.Implementations
{
    public class DonorFormDatastore : IDonorFormDatastore
    {
        private readonly DonationAppDBContext _donationAppDBContext;
        public DonorFormDatastore(DonationAppDBContext donationAppDBContext)
        {
            _donationAppDBContext = donationAppDBContext ?? throw new ArgumentNullException(nameof(donationAppDBContext));
        }

        public async Task<DonorForm> AddDonorFormAsync(DonorForm donorform)
        {
            var result = await _donationAppDBContext.DonorForm.AddAsync(donorform);
            await _donationAppDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteDonorFormAsync(string donorFormID, string userId)
        {
            var donor = await _donationAppDBContext.DonorForm.FirstOrDefaultAsync(donor => donor.Id == donorFormID);
            _donationAppDBContext.Remove(donor);
            var result = await _donationAppDBContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<DonorForm> GetDonorFormAsync(string donorFormID)
        {
            var donor = await _donationAppDBContext.DonorForm
                 .FirstOrDefaultAsync(donor => donor.Id == donorFormID);
            return donor;
        }

        public async Task<bool> UpdateDonorFormAsync(DonorForm donorUpdate)
        {
            var donor = _donationAppDBContext.DonorForm.FirstOrDefaultAsync(donor => donor.Id == donorUpdate.Id);
            _donationAppDBContext.Update(donorUpdate);
            var result = await _donationAppDBContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
