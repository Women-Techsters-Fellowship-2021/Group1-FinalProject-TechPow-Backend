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
using DonationApp.DTO.AppuserDTOs;
using DonationApp.BuisnessLogic.Implementations;
using Microsoft.AspNetCore.Authorization;

namespace DonationAppWEBAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ResetPasswordController : ControllerBase
    {
        private readonly IPasswordService _passwordService;
        private readonly IOTPGenerator _oTPGenerator;
        public ResetPasswordController(IPasswordService passwordService, IOTPGenerator oTPGenerator)
        {
            _passwordService = passwordService;
            _oTPGenerator = oTPGenerator;
        }

        [HttpPost("SendOTPCode")]
        [AllowAnonymous]
        public async Task<IActionResult> SendOTPCode([FromBody] UserEmailRequestDTO userEmailRequestDTO)
        {
            try
            {

                await _passwordService.SendOTP(userEmailRequestDTO.Email);

                return Ok("OTP sent to your Email, Please fill it in.");

                //return BadRequest();

            }

            catch (Exception)
            {

                throw new InvalidOperationException();
            }
        }

        [HttpPost("ResetPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequestDTO resetPasswordRequestDTO)
        {
          
            var result = await _passwordService.ResetPassword(resetPasswordRequestDTO);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }

}