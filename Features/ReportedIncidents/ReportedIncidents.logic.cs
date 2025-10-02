using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiftOfTheGivers.WebApp.DTOs;
using Microsoft.AspNetCore.Components;

namespace GiftOfTheGivers.WebApp.Features.ReportedIncidents
{
    public class ReportedIncidentsLogic : ComponentBase
    {
        protected List<IncidentDetailsDto> AllIncidents { get; private set; } = new();
        protected IncidentDetailsDto? SelectedIncident { get; private set; }

        // In a real application, you would inject a service to fetch this data.
        // For now, we use mock data to build the UI.
        protected override async Task OnInitializedAsync()
        {
            // Simulate a network call
            await Task.Delay(50);

            AllIncidents = new List<IncidentDetailsDto>
            {
                new() {
                    Id = 101,
                    IncidentType = "Flood",
                    LocationCity = "Pretoria",
                    LocationProvince = "Gauteng",
                    LocationAddress = "123 Floodplain St, Centurion",
                    UrgencyLevel = "Critical",
                    IncidentDate = DateTime.Now.AddHours(-3),
                    Description = "Major flooding in the Centurion area, residential homes are submerged. Immediate assistance required.",
                    Status = "Pending",
                    ReportedBy = "Jane Doe"
                },
                new() {
                    Id = 102,
                    IncidentType = "Wildfire",
                    LocationCity = "Cape Town",
                    LocationProvince = "Western Cape",
                    LocationAddress = "Near Table Mountain Park",
                    UrgencyLevel = "High",
                    IncidentDate = DateTime.Now.AddDays(-1),
                    Description = "A wildfire is spreading rapidly towards urban areas. Evacuations may be necessary.",
                    Status = "Pending",
                    ReportedBy = "John Smith"
                },
                new() {
                    Id = 103,
                    IncidentType = "Search and Rescue",
                    LocationCity = "Durban",
                    LocationProvince = "KwaZulu-Natal",
                    LocationAddress = "Off the coast near uMhlanga",
                    UrgencyLevel = "Medium",
                    IncidentDate = DateTime.Now.AddHours(-12),
                    Description = "A small boat has been reported overdue. A search and rescue operation is needed.",
                    Status = "Attending",
                    ReportedBy = "Coast Guard"
                }
            };
        }

        protected void SelectIncident(IncidentDetailsDto incident)
        {
            SelectedIncident = incident;
        }

        protected void AttendIncident()
        {
            if (SelectedIncident != null)
            {
                SelectedIncident.Status = "Attending";
                // In a real app, you would call a service to update the incident's status in the database.
                Console.WriteLine($"Incident {SelectedIncident.Id} marked as ATTENDING.");
            }
        }

        protected void DeclineIncident()
        {
            if (SelectedIncident != null)
            {
                SelectedIncident.Status = "Declined";
                // In a real app, you would call a service here.
                Console.WriteLine($"Incident {SelectedIncident.Id} marked as DECLINED.");
            }
        }
    }
}