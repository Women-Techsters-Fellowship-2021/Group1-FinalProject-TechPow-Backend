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
        Task<ServiceResponse<int>> SendOTP(UserEmailRequestDTO userEmailRequestDTO, string email);
        Task ResetPassword(ResetPassword resetPassword, string email, string newPassword);
    }
}