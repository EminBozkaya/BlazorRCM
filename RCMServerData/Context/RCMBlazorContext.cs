using Microsoft.EntityFrameworkCore;

namespace RCMServerData.Context
{
    public class RCMBlazorContext : DbContext
    {
        public RCMBlazorContext(DbContextOptions<RCMBlazorContext> options) : base(options)
        {

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