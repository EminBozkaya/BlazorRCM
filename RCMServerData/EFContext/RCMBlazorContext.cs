using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace RCMServerData.EFContext
{
    public class RCMBlazorContext : DbContext
    {
        IConfiguration? c;
        //public RCMBlazorContext(DbContextOptions<RCMBlazorContext> options) : base(options)
        //{

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(c.GetConnectionString("RCMpostgreConnection"), b => b.MigrationsAssembly("RCMServerData"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RCMBlazorContext).Assembly);
        }
    }
}




//Package Manager Console Komutları

// Add-Migration AddedFirstMigration 
// Update-Database
// Remove-Migration
//