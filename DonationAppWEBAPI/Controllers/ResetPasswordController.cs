using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using DonationApp.BuisnessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DonationApp.Models;
using DonationApp.DataStore;
using DonationApp.DataStore.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DonationAppWEBAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ResetPasswordController : ControllerBase
    {
        private readonly IPasswordService _passwordService;
        private readonly IOTPGenerator _otpGenerator;
        public ResetPasswordController(IPasswordService passwordService, IOTPGenerator otpGenerator)
        {
            _passwordService = passwordService;
            _otpGenerator = otpGenerator;
        }
        
        [HttpPost("SendOTPCode")]
        //[AllowAnonymous]
        public async Task<IActionResult> SendOTPCode()
        {
            try
            {
                var otp = await _otpGenerator.RandomNumberGenerator(100000, 999999);

                if (result.Success)
                {
                    return Ok("Token sent successfully in email");
                }
                return BadRequest(result);
            }
            catch (Exception)
            {

                throw new UnauthorizedAccessException();
            }
        }

        [HttpPost("ResetPassword")]
        //[AllowAnonymous]
        public async Task<IActionResult> ResetPassword(string email, string otp, string newPassword)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrEmpty(newPassword))
            {
                return BadRequest("Email and new password cannot be null or empty");
            }

            var res = await _passwordService.ResetPassword(resetPassword, email, newPassword);

            if (!res.Succeeded)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}