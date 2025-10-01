using GiftOftheGivers.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GiftOftheGivers.WebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}