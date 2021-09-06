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
    public class LoginAuthController : ControllerBase
    {
        private readonly ILoginAuthentication _authentication;
        public LoginAuthController(ILoginAuthentication authentication)
        {
            _authentication = authentication;
        }

        [HttpPost("Login/Donor")]
        public async Task<IActionResult> DonorLogin([FromBody] UserLoginRequestDTO userLoginRequestDTO)
        {
            try
            {
                return Ok(await _authentication.DonorLoginAsync(userLoginRequestDTO));
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
        [HttpPost("Login/Donee")]
        public async Task<IActionResult> DoneeLogin([FromBody] UserLoginRequestDTO userLoginRequestDTO)
        {
            try
            {
                return Ok(await _authentication.DoneeLoginAsync(userLoginRequestDTO));
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

            [HttpPost("Login/NGO")]
            public async Task<IActionResult> NGOLogin([FromBody] UserLoginRequestDTO userLoginRequestDTO)
            {
                try
                {
                    return Ok(await _authentication.NGOLoginAsync(userLoginRequestDTO));
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
