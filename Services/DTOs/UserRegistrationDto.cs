using System.ComponentModel.DataAnnotations;

namespace GiftOftheGivers.WebApp.Services.DTOs
{
    public class UserRegistrationDto
    {
        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(100, ErrorMessage = "Full name cannot exceed 100 characters.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Password must be at least 3 characters long.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a role.")]
        public string Role { get; set; } = string.Empty;
    }
}