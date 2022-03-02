using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace RCMServerData.EFContext
{
    public class RCMBlazorContext : DbContext
    {
        //string connection = ConfigurationManager.ConnectionStrings["RCMpostgreConnection"].ConnectionString;
        //IConfiguration? c;
        //public RCMBlazorContext(DbContextOptions<RCMBlazorContext> options) : base(options)
        //{

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql(c.GetConnectionString("RCMpostgreConnection"), b => b.MigrationsAssembly("RCMServerData"));

            //optionsBuilder.UseNpgsql(ConfigurationManager.ConnectionStrings["RCMpostgreConnection"].ConnectionString);

            optionsBuilder.UseNpgsql("User ID=postgres;password=posgres;Host=localhost;Port=5432;Database=MyBlazor;SearchPath=public");
            
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