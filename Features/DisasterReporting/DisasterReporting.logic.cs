// GiftOfTheGivers.WebApp/Features/DisasterReporting/DisasterReporting.logic.cs

using System;
using System.Security.Claims;
using System.Threading.Tasks;
using GiftOfTheGivers.WebApp.DTOs;
using GiftOfTheGivers.WebApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace GiftOfTheGivers.WebApp.Features.DisasterReporting
{
    public class DisasterReportingLogic : ComponentBase
    {
        [Inject]
        private IIncidentService IncidentService { get; set; } = default!;

        [Inject]
        private NavigationManager Navigation { get; set; } = default!;

        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;

        // Initialize the model to satisfy the non-nullable warning
        protected IncidentReportDto IncidentReportModel { get; set; } = new();
        protected string? submissionError;
        protected bool isSubmitting = false;

        protected readonly string[] UrgencyLevels = { "Low", "Medium", "High", "Critical" };

        protected override void OnInitialized()
        {
            IncidentReportModel = new IncidentReportDto
            {
                IncidentDate = DateTime.Now
            };
        }

        protected void SelectUrgency(string level)
        {
            IncidentReportModel.UrgencyLevel = level;
        }

        protected async Task HandleIncidentReportSubmissionAsync()
        {
            isSubmitting = true;
            submissionError = null;
            await InvokeAsync(StateHasChanged);

            try
            {
                var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
                var user = authState.User;

                // Find the user's ID (string) from their claims.
                var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId))
                {
                    submissionError = "Could not identify the current user. Please log out and try again.";
                    return;
                }

                // Call the service method with the string user ID.
                await IncidentService.CreateIncidentAsync(IncidentReportModel, userId);

                Navigation.NavigateTo("/");
            }
            catch (Exception)
            {
                submissionError = "A critical error occurred while submitting your report. Please try again later.";
            }
            finally
            {
                isSubmitting = false;
                await InvokeAsync(StateHasChanged);
            }
        }
    }
}