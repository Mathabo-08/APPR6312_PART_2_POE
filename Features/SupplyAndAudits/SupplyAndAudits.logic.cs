using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GiftOfTheGivers.WebApp.DTOs;
using Microsoft.AspNetCore.Components;

namespace GiftOfTheGivers.WebApp.Features.SupplyAndAudits
{
    public class SupplyAndAuditsLogic : ComponentBase
    {
        protected List<DonationAuditDto> AllDonations { get; private set; } = new();

        // We use mock data to build the UI first.
        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(50); // Simulate network call

            AllDonations = new List<DonationAuditDto>
            {
                new() {
                    DonationId = 202401,
                    PledgeDate = DateTime.Now.AddHours(-5),
                    DonorName = "Alice Johnson",
                    IsMonetary = true,
                    Amount = 1500.00m,
                    IsGoods = false,
                    Status = "Deposited"
                },
                new() {
                    DonationId = 202402,
                    PledgeDate = DateTime.Now.AddDays(-1),
                    DonorName = "Bob Williams",
                    IsMonetary = false,
                    IsGoods = true,
                    Categories = new List<string> { "Blankets", "Food" },
                    TotalQuantity = 50,
                    DonationMethod = "DropOff",
                    Status = "Received"
                },
                new() {
                    DonationId = 202403,
                    PledgeDate = DateTime.Now.AddDays(-2),
                    DonorName = "Charlie Brown",
                    IsMonetary = true,
                    Amount = 250.00m,
                    IsGoods = true,
                    Categories = new List<string> { "Medical Supplies" },
                    TotalQuantity = 10,
                    DonationMethod = "Collection",
                    Status = "Pledged"
                }
            };
        }
    }
}