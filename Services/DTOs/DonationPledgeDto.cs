using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace GiftOfTheGivers.WebApp.DTOs
{
    public class DonationPledgeDto : IValidatableObject
    {
        // Monetary Donation Fields (now nullable)
        [Range(10, 1000000, ErrorMessage = "Donation amount must be between R10 and R1,000,000.")]
        public decimal? Amount { get; set; }

        // Physical Goods Fields
        public List<string> Categories { get; set; } = new();

        [Range(1, 10000, ErrorMessage = "Quantity must be at least 1.")]
        public int? TotalQuantity { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        public string? DonationMethod { get; set; }

        [RequiredIf(nameof(DonationMethod), "Collection", ErrorMessage = "Please provide a collection address.")]
        public string? CollectionAddress { get; set; }

        // This method provides complex validation for the whole form.
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Rule 1: At least one type of donation must be made.
            if ((Amount == null || Amount <= 0) && Categories.Count == 0)
            {
                yield return new ValidationResult("Please enter a monetary donation or select at least one physical good category.");
            }

            // Rule 2: If goods are selected, quantity and method are required.
            if (Categories.Count > 0)
            {
                if (TotalQuantity == null || TotalQuantity <= 0)
                {
                    yield return new ValidationResult("Please enter the total quantity for the physical goods.", new[] { nameof(TotalQuantity) });
                }
                if (string.IsNullOrWhiteSpace(DonationMethod))
                {
                    yield return new ValidationResult("Please select a donation method for the physical goods.", new[] { nameof(DonationMethod) });
                }
            }
        }
    }

   
    public class RequiredIfAttribute : ValidationAttribute
    {
        
        private readonly string _propertyName;
        private readonly object _expectedValue;

        public RequiredIfAttribute(string propertyName, object expectedValue)
        {
            _propertyName = propertyName;
            _expectedValue = expectedValue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var instance = validationContext.ObjectInstance;
            var otherProperty = instance.GetType().GetProperty(_propertyName);
            var otherPropertyValue = otherProperty.GetValue(instance);

            if (otherPropertyValue?.Equals(_expectedValue) == true && string.IsNullOrWhiteSpace(value as string))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}