using Microsoft.AspNetCore.Components;
using GiftOfTheGivers.WebApp.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GiftOfTheGivers.WebApp.Features.Donations
{
    public class DonationsLogic : ComponentBase
    {
        protected DonationPledgeDto Pledge { get; set; } = new();

        protected List<string> AllCategories { get; } = new()
        {
            "Clothing", "Food", "Hygiene Kits", "Blankets", "Medical Supplies", "Water Storage Containers"
        };

        protected List<(string Name, string Address, string Hours)> DropOffLocations { get; } = new()
        {
            ("Pretoria Central Warehouse", "123 Industria Rd, Pretoria West", "Mon-Fri, 9am - 4pm"),
            ("Sandton Collection Point", "456 Commerce Crescent, Sandton", "Mon-Sat, 10am - 6pm"),
            ("Cape Town Depot", "789 Portside Ave, Paarden Eiland", "Mon-Fri, 8am - 3pm")
        };

        protected void ToggleCategorySelection(string category)
        {
            if (Pledge.Categories.Contains(category))
            {
                Pledge.Categories.Remove(category);
            }
            else
            {
                Pledge.Categories.Add(category);
            }
        }

        protected Task HandlePledgeSubmissionAsync()
        {
            // Logic to save the pledge will go here
            Console.WriteLine("Pledge submitted!");
            return Task.CompletedTask;
        }
    }
}