using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonationApp.Models;

namespace DonationApp.BuisnessLogic.Interfaces
{
    public interface IPasswordService
    {
        Task ResetPasswordCode(string email);
        Task ResetPassword(ResetPassword resetPassword, string email, string newPassword);
    }
}