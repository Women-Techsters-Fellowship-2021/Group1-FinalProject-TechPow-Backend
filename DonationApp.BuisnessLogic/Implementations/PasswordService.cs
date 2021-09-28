using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonationApp.BuisnessLogic.Interfaces;
using DonationApp.Models;
using DonationApp.DataStore.Interfaces;
using Microsoft.AspNetCore.Identity;
using DonationApp.DTO.AppuserDTOs;

namespace DonationApp.BuisnessLogic.Implementations
{
    public class PasswordService : IPasswordService
    {
        
        private readonly UserManager<AppUser> _userManager;
        private readonly IOTPGenerator _otpGenerator;
        private readonly IPasswordDataStore _passwordDataStore;
        private readonly IEmailService _emailService;
        public PasswordService(UserManager<AppUser> userManager, IOTPGenerator otpGenerator, IPasswordDataStore passwordDataStore, IEmailService emailService)
        {
            _userManager = userManager;
            _otpGenerator = otpGenerator;
            _passwordDataStore = passwordDataStore;
            _emailService = emailService;
        }

        public Task ResetPassword(ResetPassword resetPassword, string email, string newPassword)
        {
            throw new NotImplementedException();
        }

        public async Task SendOTP(string email)
        {
            //Generate Password reset token
           // var token = await _userManager.GeneratePasswordResetTokenAsync(userEmailRequestDTO.Email);

            //Generate OTP
            int otp =_otpGenerator.RandomNumberGenerator(100000, 999999);
            await _emailService.SendOTPEmail(email, otp);
            
            //if we were to use link, generate password reset link
            //var passwordResetLink = UriBuilder.Action("ResetPassword", "Account", new {email = ModuleHandle.Email, token = token}, Request.Scheme);
            //logger.Log(LogLevel.Warning, passwordResetLink);

            //var resetPassword = new ResetPassword()
            //{
            //    Email = email,
            //    OTP = otp.ToString(),
            //    Token = token,
            //    UserId = user.Id,
            //    InsertDateTimeUTC = DateTime.UtcNow
            //};

            //var newResetPassword = await _passwordDataStore.ResetPasswordAsync(resetPassword);

            
        }

        //public async Task ResetPassword(ResetPassword resetPassword, string email, string newPassword)
        //{
        //    var user = await _userManager.FindByEmailAsync(email);

        //    var resetPasswordDetails = _passwordDataStore.GetTokenFromOTPAsync(resetPassword);

        //    //verify if token is older than 15 minutes
        //    var expirationDateTimeUtc = resetPasswordDetails.InsertDateTimeUTC.AddMinutes(15);

        //    if (expirationDateTimeUtc < DateTime.UtcNow)
        //    {
        //        return BadRequest("OTP is expired, please generate a new OTP");
        //    }

        //    var res = await _userManager.ResetPasswordAsync(user, resetPasswordDetails.Token, newPassword);
        //    return res;
        //}
    }
}