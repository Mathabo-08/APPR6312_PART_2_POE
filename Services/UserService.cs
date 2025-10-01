using GiftOftheGivers.WebApp.Data;
using GiftOftheGivers.WebApp.Models;
using GiftOftheGivers.WebApp.Services.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GiftOftheGivers.WebApp.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(ApplicationDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> RegisterUserAsync(UserRegistrationDto registrationData)
        {
            try
            {
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == registrationData.Email);
                if (existingUser != null)
                {
                    // User with this email already exists
                    return false;
                }

                var newUser = new User
                {
                    FirstName = registrationData.FirstName,
                    LastName = registrationData.LastName,
                    Email = registrationData.Email
                };

                // Hash the password before saving
                newUser.PasswordHash = _passwordHasher.HashPassword(newUser, registrationData.Password);

                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (implementation depends on your logging strategy)
                return false;
            }
        }
    }
}