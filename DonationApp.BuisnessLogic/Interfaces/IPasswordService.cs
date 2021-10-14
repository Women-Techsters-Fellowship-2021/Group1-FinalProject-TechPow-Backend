using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonationApp.Models;
using DonationApp.DTO.AppuserDTOs;

namespace DonationApp.BuisnessLogic.Interfaces
{
    public interface IPasswordService
    {
        Task SendOTP(string email);
        Task <ServiceResponse<bool>> ResetPassword(ResetPasswordRequestDTO resetPasswordRequestDTO);
    }
}