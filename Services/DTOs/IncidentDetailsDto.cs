using System;

namespace GiftOfTheGivers.WebApp.DTOs
{
    public class IncidentDetailsDto
    {
        public int Id { get; set; }
        public string IncidentType { get; set; }
        public string LocationCity { get; set; }
        public string LocationProvince { get; set; }
        public string LocationAddress { get; set; }
        public string UrgencyLevel { get; set; }
        public DateTime IncidentDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // "Pending", "Attending", "Declined"
        public string ReportedBy { get; set; } // Name of the user who reported it
    }
}