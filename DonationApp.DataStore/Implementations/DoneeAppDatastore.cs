using DonationApp.DataStore.Interfaces;
using DonationApp.DTO.UserApplicationDTOs;
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
        public async Task<DoneeApplication> AddDoneeAppAsync(DoneeApplication donee)
        {
            var result = await _donationAppDBContext.DoneeApplication.AddAsync(donee);
            await _donationAppDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteDoneeAppAsync(string DoneeID)
        {
            var donee = await _donationAppDBContext.DoneeApplication.FirstOrDefaultAsync(donee => donee.Id == DoneeID);
            _donationAppDBContext.Remove(donee);
            var result = await _donationAppDBContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<DoneeApplication> GetDoneeAppAsync(string doneeID)
        {
            var donee = await _donationAppDBContext.DoneeApplication
                 .FirstOrDefaultAsync(donee => donee.Id == doneeID);
            return donee;
        }

        public async Task<bool> UpdateDoneeAppAsync(DoneeApplication doneeUpdate)
        {
            var donee = _donationAppDBContext.DoneeApplication.FirstOrDefaultAsync(donee => donee.Id == doneeUpdate.Id);
            _donationAppDBContext.Update(doneeUpdate);
            var result = await _donationAppDBContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateDoneeAppStatus(DoneeApplication doneeAppStatusUpdate)
        {
            var donee = _donationAppDBContext.DoneeApplication.FirstOrDefaultAsync(donee => donee.Id == doneeAppStatusUpdate.Id);
            _donationAppDBContext.Update(doneeAppStatusUpdate);
            var result = await _donationAppDBContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<DoneeApplication>> GetAllDoneeAppAsync()
        {
            var doneeApplications = await _donationAppDBContext.DoneeApplication.ToListAsync();
            return doneeApplications;


        }
    }
}
