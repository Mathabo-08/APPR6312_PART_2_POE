using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GiftOfTheGivers.WebApp.DTOs;
using Microsoft.AspNetCore.Components;

namespace GiftOfTheGivers.WebApp.Features.AnalyticsDashboard
{
    public class AnalyticsDashboardLogic : ComponentBase
    {
        protected AnalyticsDashboardDto? DashboardData { get; private set; }
        protected bool IsLoading = true;

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(250); // Simulate loading data

            DashboardData = new AnalyticsDashboardDto
            {
                TotalVolunteers = 124,
                ActiveEvents = 2,
                CompletedEvents = 18,
                IncidentsByType = new Dictionary<string, int>
                {
                    { "Flood", 8 },
                    { "Wildfire", 5 },
                    { "Earthquake", 2 },
                    { "Drought", 4 },
                    { "Search and Rescue", 6 },
                    { "Medical Emergency", 1 }
                }
            };

            IsLoading = false;
        }

        protected string GetIconForIncidentType(string incidentType) => incidentType switch
        {
            "Flood" => "oi-droplet",
            "Wildfire" => "oi-fire",
            "Earthquake" => "oi-pulse",
            "Drought" => "oi-sun",
            "Search and Rescue" => "oi-magnifying-glass",
            "Medical Emergency" => "oi-medical-cross",
            _ => "oi-question-mark"
        };

        protected string GetIconBgForIncidentType(string incidentType) => incidentType switch
        {
            "Flood" => "flood-icon",
            "Wildfire" => "wildfire-icon",
            "Earthquake" => "earthquake-icon",
            "Drought" => "drought-icon",
            "Search and Rescue" => "rescue-icon",
            "Medical Emergency" => "medical-icon",
            _ => "default-icon"
        };
    }
}