using DonationApp.BuisnessLogic.Implementations;
using DonationApp.BuisnessLogic.Interfaces;
using DonationApp.DTO.AppuserDTOs;
using DonationApp.DTO.Mappings;
using DonationApp.DTO.UserApplicationDTOs;
using DonationApp.Models.Mappings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
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
                if (result.Success)
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

                if (result.Success)
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

        [HttpGet]
        public async Task<IActionResult> GetUser([FromQuery] string userID)
        {
            try
            {
                var user = await _authentication.GetAppUser(userID);
                var result = AppuserMapping.GetUserResponseDTO(user.Data);
                if (!(result == null))
                {
                    return Ok(result);
                }
                return NotFound(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPatch]
        public async Task<IActionResult> UpdateAppuser_Patch(UpdateUserRequestDTO updateUserRequestDTO, [FromQuery] string userID)
        {
            try
            {
                var result = await _authentication.UpdateUserByPatch(updateUserRequestDTO,userID);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                return BadRequest(result.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

          }
}
