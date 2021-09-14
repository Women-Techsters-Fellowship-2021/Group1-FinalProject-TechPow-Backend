using DonationApp.DataStore.Interfaces;
using DonationApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationApp.DataStore.Implementations
{
    public class DoneeAppDatastore : IDoneeAppDatastore
    {
        private readonly DonationAppDBContext _donationAppDBContext;
        public DoneeAppDatastore(DonationAppDBContext donationAppDBContext)
        {
            _donationAppDBContext = donationAppDBContext;
        }
        public async Task<Donee> AddDoneeAppAsync(Donee donee)
        {
            var result = await _donationAppDBContext.Donees.AddAsync(donee);
            await _donationAppDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteDoneeAppAsync(string DoneeID, string userId)
        {
            var donee = await _donationAppDBContext.Donees.FirstOrDefaultAsync(donee => donee.Id ==DoneeID);
            _donationAppDBContext.Remove(donee);
            var result = await _donationAppDBContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<Donee> GetDoneeAppAsync(string doneeID)
        {
            var donee = await _donationAppDBContext.Donees
                 .FirstOrDefaultAsync(donee=>donee.Id == doneeID);
            return donee;
        }

        public async Task<bool> UpdateDoneeAppAsync(Donee doneeUpdate)
        {
            var donee = _donationAppDBContext.Donees.FirstOrDefaultAsync(donee => donee.Id == doneeUpdate.Id);
            _donationAppDBContext.Update(doneeUpdate);
            var result = await _donationAppDBContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
