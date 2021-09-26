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
        public ResetPasswordController(IPasswordService passwordService)
        {
            _passwordService = passwordService ?? throw new ArgumentNullException(nameof(passwordService));
        }
        
        [HttpPost("SendResetPasswordCode")]
        //[AllowAnonymous]
        public async Task<IActionResult> SendResetPasswordCode(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return BadRequest("Email field should not be null or empty");
                }

                var result = await _passwordService.ResetPasswordCode(email);

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