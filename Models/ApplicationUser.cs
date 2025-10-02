using Microsoft.AspNetCore.Identity;

namespace GiftOfTheGivers.WebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}