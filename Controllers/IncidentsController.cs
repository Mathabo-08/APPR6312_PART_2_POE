// GiftOfTheGivers.WebApp/Controllers/IncidentsController.cs

using System;
using System.Security.Claims;
using System.Threading.Tasks;
using GiftOfTheGivers.WebApp.DTOs;
using GiftOfTheGivers.WebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GiftOfTheGivers.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidentService _incidentService;

        public IncidentsController(IIncidentService incidentService)
        {
            _incidentService = incidentService ?? throw new ArgumentNullException(nameof(incidentService));
        }

        [HttpPost]
        public async Task<IActionResult> ReportIncident([FromBody] IncidentReportDto incidentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Retrieve the user's ID (string) from their authenticated session.
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("User ID could not be determined.");
                }

                // Pass the string ID directly to the service.
                await _incidentService.CreateIncidentAsync(incidentDto, userId);

                return Ok(new { message = "Incident reported successfully." });
            }
            catch (Exception)
            {
                return StatusCode(500, "An internal server error occurred. Please try again later.");
            }
        }
    }
}