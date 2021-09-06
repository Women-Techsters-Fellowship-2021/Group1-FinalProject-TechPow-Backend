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
    public class RegAuthController : ControllerBase
    {
        private readonly IRegAuthentication _authentication;
        public RegAuthController(IRegAuthentication authentication)
        {
            _authentication = authentication;
        }

        [HttpPost("Donee")]
        public async Task<IActionResult> DoneeRegister(DoneeRegRequestDTO doneeRegRequestDTO)
        {
            try
            {
                var result = await _authentication.DoneeRegistrationAsync(doneeRegRequestDTO);

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
        [HttpPost("Donor")]
        public async Task<IActionResult> DonorRegister(DonorRegRequestDTO donorRegRequestDTO)
        {
            try
            {
                var result = await _authentication.DonorRegistrationAsync(donorRegRequestDTO);

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

        [HttpPost("NGO")]
        public async Task<IActionResult> NGORegister(NGORegRequestDTO ngoRegRequestDTO)
        {
            try
            {
                var result = await _authentication.NGORegistrationAsync(ngoRegRequestDTO);

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
    }
}
