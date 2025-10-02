// GiftOfTheGivers.WebApp/Models/Incident.cs

using GiftOfTheGivers.WebApp.Models;

public class Incident
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty; 
    public ApplicationUser? User { get; set; }
    public string IncidentType { get; set; } = string.Empty;
    public DateTime IncidentDate { get; set; }
    public string LocationAddress { get; set; } = string.Empty;
    public string LocationCity { get; set; } = string.Empty;
    public string LocationProvince { get; set; } = string.Empty;
    public string UrgencyLevel { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime ReportedAt { get; set; }
}