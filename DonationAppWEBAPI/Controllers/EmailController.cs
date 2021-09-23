using DonationApp.BuisnessLogic.Interfaces;
using DonationApp.DTO.EmailDTO;
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
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("SendEmail")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequestDTO emailRequestDTO)
        {
            try
            {
                await _emailService.SendEmail(emailRequestDTO);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
