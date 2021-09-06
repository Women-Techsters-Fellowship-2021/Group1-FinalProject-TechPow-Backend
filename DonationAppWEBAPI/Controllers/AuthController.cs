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

                return Created("", result);
            }
            catch (MissingFieldException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDTO userLoginRequestDTO)
        {
            try
            {
                return Ok(await _authentication.UserLoginAsync(userLoginRequestDTO));
            }
            catch (AccessViolationException)
            {
                return BadRequest();
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
