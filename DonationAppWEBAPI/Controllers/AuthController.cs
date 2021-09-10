using DonationApp.BuisnessLogic.Interfaces;
using DonationApp.DTO.AppuserDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonationAppWEBAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthentication _authentication;
        public AuthController(IAuthentication authentication)
        {
            _authentication = authentication;
        }

        
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegRequestDTO userRegRequestDTO)
        {
            try
            {
                var result = await _authentication.UserRegistrationAsync(userRegRequestDTO);
                if(result.Success)
                {
                    return Created("", result);
                }

                return BadRequest(result);
                               
            }
           
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDTO userLoginRequestDTO)
        {
            try
            {
                var result = await _authentication.UserLoginAsync(userLoginRequestDTO);
               
                if(result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
           

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
