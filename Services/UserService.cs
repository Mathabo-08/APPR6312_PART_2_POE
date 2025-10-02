using GiftOftheGivers.WebApp.Services.DTOs;
using GiftOfTheGivers.WebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace GiftOftheGivers.WebApp.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<RegistrationResult> RegisterUserAsync(UserRegistrationDto registrationData)
        {
            try
            {
                var existingUser = await _userManager.FindByEmailAsync(registrationData.Email);
                if (existingUser != null)
                {
                    return new RegistrationResult(false, "This email address is already in use.");
                }

                var user = new ApplicationUser
                {
                    FullName = registrationData.FullName,
                    Email = registrationData.Email,
                    UserName = registrationData.Email,
                };

                var result = await _userManager.CreateAsync(user, registrationData.Password);

                if (result.Succeeded)
                {
                    // Add user to role
                    await _userManager.AddToRoleAsync(user, registrationData.Role);
                    return new RegistrationResult(true);
                }
                else
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    return new RegistrationResult(false, errors);
                }
            }
            catch (Exception)
            {
                return new RegistrationResult(false, "An unexpected error occurred during registration.");
            }
        }

        public async Task<ApplicationUser?> ValidateUserCredentialsAsync(UserLoginDto loginData)
        {
            var user = await _userManager.FindByEmailAsync(loginData.Email);
            if (user == null)
            {
                return null;
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginData.Password, lockoutOnFailure: false);
            return result.Succeeded ? user : null;
        }
    }
}