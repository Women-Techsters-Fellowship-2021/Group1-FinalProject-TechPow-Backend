using DonationApp.BuisnessLogic.Interfaces;
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
    public class DonorController : ControllerBase
    {
        private readonly IDonorServices _donorServices;
        public DonorController(IDonorServices donorServices)
        {
            _donorServices = donorServices ?? throw new ArgumentNullException(nameof(donorServices));
        }

        [HttpGet]
        public async Task<IActionResult> GetDonorForm([FromQuery] string donorFormID)
        {
            try
            {
                var donor = await _donorServices.GetDonorForm(donorFormID);
                var result = DonorMappings.GetDonorResponseDTO(donor.Data);
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
        [HttpPost]
        [Authorize(Roles = "Donor")]
        public async Task<IActionResult> AddDonorForm(DonorInfoRequestDTO donorInfoRequestDTO)
        {
            try
            {
                var loggedInUser = HttpContext.User.FindFirst(user => user.Type == ClaimTypes.NameIdentifier).Value;
                var newDonor = await _donorServices.DonorFormAsync(donorInfoRequestDTO);
                if (newDonor.Success)
                {
                    return CreatedAtAction(nameof(GetDonorForm), new { donorId = newDonor.Data.Id }, newDonor);
                }
                return BadRequest(newDonor);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateDonorForm_Put(UpdateDonorInfoRequest updateDonorInfoRequest, [FromQuery] string donorInfoID)
        {
            try
            {
                var loggedInUser = HttpContext.User.FindFirst(user => user.Type == ClaimTypes.NameIdentifier).Value;
                var result = await _donorServices.UpdateDonorFormByPut(updateDonorInfoRequest, donorInfoID, loggedInUser);
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

        [HttpPatch]
        [Authorize]
        public async Task<IActionResult> UpdateDonorForm_Patch(UpdateDonorInfoRequest updateDonorInfoRequest, [FromQuery] string donorInfoID)
        {
            try
            {
                var loggedInUser = HttpContext.User.FindFirst(user => user.Type == ClaimTypes.NameIdentifier).Value;
                var result = await _donorServices.UpdateDonorFormByPatch(updateDonorInfoRequest, donorInfoID, loggedInUser);
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

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Donor")]
        public async Task<IActionResult> DeleteDonorForm([FromQuery] string donorFormID)
        {
            try
            {
                //var loggedInUser = HttpContext.User.FindFirst(user => user.Type == ClaimTypes.NameIdentifier).Value;
                var result = await _donorServices.DeleteDonorForm(donorFormID);
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
