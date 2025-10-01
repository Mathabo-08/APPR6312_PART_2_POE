using GiftOftheGivers.WebApp.Services.DTOs;

namespace GiftOftheGivers.WebApp.Services
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(UserRegistrationDto registrationData);
    }
}