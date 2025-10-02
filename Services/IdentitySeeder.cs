// GiftOfTheGivers.WebApp/Services/IdentitySeeder.cs

using GiftOfTheGivers.WebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace GiftOftheGivers.WebApp.Services
{
    /// <summary>
    /// Utility to seed initial roles and users into the database.
    /// </summary>
    public static class IdentitySeeder
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Ensure the services are not null
            ArgumentNullException.ThrowIfNull(userManager);
            ArgumentNullException.ThrowIfNull(roleManager);

            await SeedRolesAsync(roleManager);
            await SeedAdminUserAsync(userManager);
        }

        /// <summary>
        /// Creates the core application roles if they don't already exist.
        /// </summary>
        private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Admin", "Volunteer", "Donor" };

            foreach (var roleName in roleNames)
            {
                // The check for existence makes this method idempotent (safe to run multiple times)
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        /// <summary>
        /// Creates a default administrator user if one does not already exist.
        /// </summary>
        private static async Task SeedAdminUserAsync(UserManager<ApplicationUser> userManager)
        {
            const string adminEmail = "admin@giftofthegivers.org";

            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FullName = "Administrator",
                    EmailConfirmed = true // Admin account is confirmed by default
                };

                // IMPORTANT: Use a strong password from a secure configuration source in a real application.
                var result = await userManager.CreateAsync(adminUser, "AdminPass123!");

                if (result.Succeeded)
                {
                    // This is the crucial step to assign the 'Admin' role.
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}