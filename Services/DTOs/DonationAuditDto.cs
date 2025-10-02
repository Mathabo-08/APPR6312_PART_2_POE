using System;
using System.Collections.Generic;

namespace GiftOfTheGivers.WebApp.DTOs
{
    public class DonationAuditDto
    {
        public int DonationId { get; set; }
        public DateTime PledgeDate { get; set; }
        public string DonorName { get; set; } = string.Empty;
        public bool IsMonetary { get; set; }
        public decimal? Amount { get; set; }
        public bool IsGoods { get; set; }
        public List<string>? Categories { get; set; }
        public int? TotalQuantity { get; set; }
        public string? DonationMethod { get; set; }
        public string Status { get; set; } // "Pledged", "Collected", "Deposited"
    }
}