public class IncidentReportDto
{
    public string IncidentType { get; set; } = string.Empty;
    public DateTime IncidentDate { get; set; }
    public string LocationAddress { get; set; } = string.Empty;
    public string LocationCity { get; set; } = string.Empty;
    public string LocationProvince { get; set; } = string.Empty;
    public string UrgencyLevel { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}