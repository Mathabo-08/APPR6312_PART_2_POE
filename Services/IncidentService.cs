// GiftOfTheGivers.WebApp/Services/IncidentService.cs

using System;
using System.Threading.Tasks;
using GiftOfTheGivers.WebApp.Data.Repositories;
using GiftOfTheGivers.WebApp.DTOs;
using GiftOfTheGivers.WebApp.Models;

namespace GiftOfTheGivers.WebApp.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly IIncidentRepository _incidentRepository;

        public IncidentService(IIncidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository ?? throw new ArgumentNullException(nameof(incidentRepository));
        }

        public async Task CreateIncidentAsync(IncidentReportDto incidentDto, string reportingUserId) // <-- CHANGE INT TO STRING
        {
            var incident = new Incident
            {
                UserId = reportingUserId, // This will now work correctly
                IncidentType = incidentDto.IncidentType,
                IncidentDate = incidentDto.IncidentDate,
                LocationAddress = incidentDto.LocationAddress,
                LocationCity = incidentDto.LocationCity,
                LocationProvince = incidentDto.LocationProvince,
                UrgencyLevel = incidentDto.UrgencyLevel,
                Description = incidentDto.Description,
                Status = "Submitted",
                ReportedAt = DateTime.UtcNow
            };

            await _incidentRepository.AddAsync(incident);
        }
    }
}