using System.Collections.Generic;

namespace GiftOfTheGivers.WebApp.DTOs
{
    public class AnalyticsDashboardDto
    {
        public int TotalVolunteers { get; set; }
        public int ActiveEvents { get; set; }
        public int CompletedEvents { get; set; }
        public Dictionary<string, int> IncidentsByType { get; set; } = new();
    }
}