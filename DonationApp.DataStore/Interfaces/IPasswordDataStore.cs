using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonationApp.Models;

namespace DonationApp.DataStore.Interfaces
{
    public interface IPasswordDataStore
    {
        Task<ResetPassword> ResetPasswordAsync(ResetPassword resetPassword);
        Task<ResetPassword> GetTokenFromOTPAsync(ResetPassword resetPassword);
    }

}