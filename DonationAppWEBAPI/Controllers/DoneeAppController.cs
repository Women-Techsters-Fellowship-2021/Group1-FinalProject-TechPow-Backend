using DonationApp.BuisnessLogic.Interfaces;
using DonationApp.DTO.UserApplicationDTOs;
using DonationApp.Models;
using DonationApp.Models.Mappings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DonationAppWEBAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DoneeAppController : ControllerBase
    {
        private readonly IDoneeServices _doneeServices;


        public DoneeAppController(IDoneeServices doneeServices)
        {
            _doneeServices = doneeServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoneeApp([FromQuery] string doneeID)
        {
            try
            {
                var donee = await _doneeServices.GetDoneeApp(doneeID);
                var result = DoneeMappings.GetDoneeResponseDTO(donee.Data);
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

        [HttpGet("AllDoneeApp")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllDoneeApplications()
        {
            List<DoneeResponseDTO> resultList = new List<DoneeResponseDTO>();
            try
            {
                var allDoneeApplication = await _doneeServices.GetAllDoneeApplications();
                if (!allDoneeApplication.Success)
                {
                    return BadRequest(allDoneeApplication);
                }
                for (int i = 0; i < allDoneeApplication.Data.Count; i++)
                {
                    var result = DoneeMappings.GetDoneeResponseDTO(allDoneeApplication.Data[i]);
                    if (!(result == null))
                    {
                        resultList.Add(result);
                    }
                }
                if (!(resultList.Count == 0))
                {
                    return Ok(resultList);
                }
                return NotFound(resultList);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }



        [HttpPost]
        [Authorize(Roles = "Donee")]

        public async Task<IActionResult> AddApplication(DoneeAppRequestDTO doneeAppRequestDTO)
        {
            try
            {
                var loggedInUser = HttpContext.User.FindFirst(user => user.Type == ClaimTypes.NameIdentifier).Value;
                var newDonee = await _doneeServices.DoneeApplicationAsync(doneeAppRequestDTO);
                if (newDonee.Success)
                {
                    return CreatedAtAction(nameof(GetDoneeApp), new { doneeId = newDonee.Data.Id }, newDonee);
                }
                return BadRequest(newDonee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateDoneeApp_Put(UpdateDoneeAppRequestDTO updateDoneeAppRequestDTO, [FromQuery] string doneeID)
        {

            try
            {
                var loggedInUser = HttpContext.User.FindFirst(user => user.Type == ClaimTypes.NameIdentifier).Value;
                var result = await _doneeServices.UpdateDoneeAppByPut(updateDoneeAppRequestDTO, doneeID, loggedInUser);
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
        public async Task<IActionResult> UpdateDoneeApp_Patch(UpdateDoneeAppRequestDTO updateDoneeAppRequestDTO, [FromQuery] string doneeID)
        {
            try
            {
                var loggedInUser = HttpContext.User.FindFirst(user => user.Type == ClaimTypes.NameIdentifier).Value;
                var result = await _doneeServices.UpdateDoneeAppByPatch(updateDoneeAppRequestDTO, doneeID, loggedInUser);
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

        [HttpPatch("AppStatusUpdate")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateDoneeAppStatus_Patch(UpdateDoneeAppRequestDTO updateDoneeAppRequestDTO, [FromQuery] string doneeID)
        {
            try
            {
                var loggedInUser = HttpContext.User.FindFirst(user => user.Type == ClaimTypes.NameIdentifier).Value;
                var result = await _doneeServices.UpdateDoneeAppStatusByPatch(updateDoneeAppRequestDTO, doneeID, loggedInUser);
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
        public async Task<IActionResult> DeleteDoneeApp([FromQuery] string doneeID)
        {
            try
            {
                var loggedInUser = HttpContext.User.FindFirst(user => user.Type == ClaimTypes.NameIdentifier).Value;
                var result = await _doneeServices.DeleteDoneeApp(doneeID, loggedInUser);
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
