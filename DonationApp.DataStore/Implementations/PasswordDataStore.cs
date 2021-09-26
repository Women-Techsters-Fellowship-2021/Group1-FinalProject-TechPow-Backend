using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonationApp.Models;
using DonationApp.DataStore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DonationApp.DataStore.Implementations
{
    public class PasswordDataStore : IPasswordDataStore
    {
        private readonly DonationAppDBContext _donationAppDBContext;
        public PasswordDataStore(DonationAppDBContext donationAppDBContext)
        {
            _donationAppDBContext = donationAppDBContext ?? throw new ArgumentNullException(nameof(donationAppDBContext));
        }
        public async Task<ResetPassword> ResetPasswordAsync(ResetPassword resetPassword)
        {
            var result = await _donationAppDBContext.ResetPassword.AddAsync(resetPassword);
            await _donationAppDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ResetPassword> GetTokenFromOTPAsync(ResetPassword resetPassword)
        {
            //Getting token from otp
            var result = await _donationAppDBContext.ResetPassword
            .Where(resetPass => resetPass.OTP == resetPassword.OTP && resetPass.UserId == resetPassword.UserId)
            .OrderByDescending(resetPass => resetPass.InsertDateTimeUTC)
            .FirstOrDefaultAsync();
            return result;
        }
    }
}