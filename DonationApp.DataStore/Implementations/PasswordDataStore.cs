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
            _donationAppDBContext = donationAppDBContext;
        }
        public async Task<ResetPassword> ResetPasswordAsync(ResetPassword resetPassword)
        {
            var result = await _donationAppDBContext.ResetPassword.AddAsync(resetPassword);
            await _donationAppDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ResetPassword> GetTokenFromOTPAsync(string email)
        {
            //Getting token from otp

            var resetPassword = await _donationAppDBContext.ResetPassword.FirstOrDefaultAsync( user => user.Email == email);
            //var result = await _donationAppDBContext.ResetPassword
            //.Where(resetPass => resetPass.OTP == resetPassword.OTP && resetPass.UserId == resetPassword.UserId)
            //.OrderByDescending(resetPass => resetPass.InsertDateTimeUTC)
            //.FirstOrDefaultAsync();
            return resetPassword;
        }
    }
}