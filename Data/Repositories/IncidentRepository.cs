using System.Threading.Tasks;
using GiftOfTheGivers.WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GiftOfTheGivers.WebApp.Data.Repositories
{
    /// <summary>
    /// Implements data operations for Incidents using Entity Framework Core.
    /// </summary>
    public class IncidentRepository : IIncidentRepository
    {
        private readonly ApplicationDbContext _context;

        public IncidentRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(Incident incident)
        {
            if (incident == null)
            {
                throw new ArgumentNullException(nameof(incident));
            }

            await _context.Incidents.AddAsync(incident);
            await _context.SaveChangesAsync();
        }
    }
}