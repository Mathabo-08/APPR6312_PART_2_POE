// GiftOfTheGivers.WebApp/Services/IIncidentService.cs

using GiftOfTheGivers.WebApp.DTOs;
using System.Threading.Tasks;

namespace GiftOfTheGivers.WebApp.Services
{
    public interface IIncidentService
    {
        Task CreateIncidentAsync(IncidentReportDto incidentDto, string reportingUserId); 
    }
}