using System.Threading.Tasks;
using GiftOfTheGivers.WebApp.Models;

namespace GiftOfTheGivers.WebApp.Data.Repositories
{
    /// <summary>
    /// Defines the contract for data operations related to Incidents.
    /// </summary>
    public interface IIncidentRepository
    {
        Task AddAsync(Incident incident);
    }
}