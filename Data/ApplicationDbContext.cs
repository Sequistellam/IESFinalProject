using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FInalprojectAPI.Models;

namespace FInalprojectAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Define DbSet properties for tables here
        public DbSet<SwimmingResult>? SwimmingResults { get; set; } 
    }
}