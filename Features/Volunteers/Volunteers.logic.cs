using Microsoft.AspNetCore.Components;
using GiftOfTheGivers.WebApp.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GiftOfTheGivers.WebApp.Features.Volunteers
{
    public class VolunteersLogic : ComponentBase
    {
        protected VolunteerProfileDto Profile { get; set; } = new();

        protected List<string> AllSkills { get; } = new() { "Medical Training", "Logistics", "Counselling", "Manual Labor", "Administration" };
        protected List<string> AllAvailability { get; } = new() { "Weekdays", "Weekends", "Mornings", "Afternoons", "Evenings" };

        protected void ToggleSkillSelection(string skill)
        {
            if (Profile.Skills.Contains(skill))
            {
                Profile.Skills.Remove(skill);
            }
            else
            {
                Profile.Skills.Add(skill);
            }
        }

        protected void ToggleAvailabilitySelection(string time)
        {
            if (Profile.Availability.Contains(time))
            {
                Profile.Availability.Remove(time);
            }
            else
            {
                Profile.Availability.Add(time);
            }
        }

        protected Task HandleRegistrationAsync()
        {
            // TODO: Implement logic to send the volunteer profile to a backend service.
            Console.WriteLine("Volunteer registration submitted!");
            return Task.CompletedTask;
        }
    }
}