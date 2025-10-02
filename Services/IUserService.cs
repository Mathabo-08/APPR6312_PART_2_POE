// IUserService.cs
using GiftOftheGivers.WebApp.Services.DTOs;
using GiftOfTheGivers.WebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace GiftOftheGivers.WebApp.Services
{
    public interface IUserService
    {
        Task<RegistrationResult> RegisterUserAsync(UserRegistrationDto registrationData);
        Task<ApplicationUser?> ValidateUserCredentialsAsync(UserLoginDto loginData);
    }

    public record RegistrationResult(bool Success, string? ErrorMessage = null);
}
