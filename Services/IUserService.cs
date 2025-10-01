using GiftOftheGivers.WebApp.Models;
using GiftOftheGivers.WebApp.Services.DTOs;

namespace GiftOftheGivers.WebApp.Services
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(UserRegistrationDto registrationData);
        // method for logging in
        Task<User?> ValidateUserCredentialsAsync(UserLoginDto loginData);
    }
}