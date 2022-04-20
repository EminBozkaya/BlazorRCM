using Microsoft.EntityFrameworkCore;
using RCMServerData.Models;
using System.Configuration;

namespace RCMServerData.EFContext
{
    public class RCMBlazorContext : DbContext
    {
        //public RCMBlazorContext():base()
        //{
        //}

        //string connection = ConfigurationManager.ConnectionStrings["RCMpostgreConnection"].ConnectionString;
        //IConfiguration? c;
        //public RCMBlazorContext(DbContextOptions<RCMBlazorContext> options) : base(options)
        //{
        //}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //string constr = AppSettings.Current.AppConnection;

            string constr = GetConnStrExtension.Current.AppConnection;

            optionsBuilder.UseNpgsql(constr);
            //optionsBuilder.UseNpgsql(constr,option=>option.MigrationsAssembly("RCMServerData"));


            //optionsBuilder.UseNpgsql("User ID=postgres;password=posgres;Host=localhost;Port=5432;Database=MyBlazor8;SearchPath=public");



            // optionsBuilder.EnableSensitiveDataLogging();
        }

        #region DbSet Properties

        //public DbSet<AdressOfCustomer>? AdressOfCustomers { get; set; }


        //public DbSet<AuthorityType>? AuthorityTypes { get; set; }
        //public DbSet<Branch>? Branches { get; set; }


        //public DbSet<BranchCaseType>? BranchCaseTypes { get; set; }
        //public DbSet<BranchCaseTypeFlow>? BranchCaseTypeFlows { get; set; }
        //public DbSet<BranchConsumption>? BranchConsumptions { get; set; }
        //public DbSet<BranchCreditCard>? BranchCreditCards { get; set; }
        //public DbSet<BranchCreditCardFlow>? BranchCreditCardFlows { get; set; }
        //public DbSet<BranchDailyRevenue>? BranchDailyRevenues { get; set; }
        //public DbSet<BranchProductPrice>? BranchProductPrices { get; set; }
        //public DbSet<BranchRevenueDistribution>? BranchRevenueDistributions { get; set; }
        //public DbSet<BranchStock>? BranchStocks { get; set; }
        //public DbSet<BranchSupplier>? BranchSuppliers { get; set; }
        //public DbSet<BranchStockEntry>? BranchStockEntries { get; set; }
        //public DbSet<CaseType>? CaseTypes { get; set; }
        //public DbSet<ConsumeType>? ConsumeTypes { get; set; }
        //public DbSet<CreditCard>? CreditCards { get; set; }
        //public DbSet<Customer>? Customers { get; set; }
        //public DbSet<Employee>? Employees { get; set; }
        //public DbSet<EmployeeMoneyFlow>? EmployeeMoneyFlows { get; set; }
        //public DbSet<EmployeePaymentType>? EmployeePaymentTypes { get; set; }
        //public DbSet<EmployeeRollCall>? EmployeeRollCalls { get; set; }
        //public DbSet<ExpenseFlow>? ExpenseFlows { get; set; }
        //public DbSet<ExpenseType>? ExpenseTypes { get; set; }


        //public DbSet<FirmType>? FirmTypes { get; set; }


        //public DbSet<MyException>? MyExceptions { get; set; }
        //public DbSet<PositionType>? PositionTypes { get; set; }
        //public DbSet<Product>? Products { get; set; }
        //public DbSet<ProductCategory>? ProductCategories { get; set; }
        //public DbSet<ProductPhoto>? ProductPhotoes { get; set; }
        //public DbSet<RawMaterial>? RawMaterials { get; set; }
        //public DbSet<RollCallType>? RollCallTypes { get; set; }
        //public DbSet<SalaryType>? SalaryTypes { get; set; }
        //public DbSet<Sale>? Sales { get; set; }
        //public DbSet<SaleNote>? SaleNotes { get; set; }
        //public DbSet<SaleNoteCategory>? SaleNoteCategories { get; set; }
        //public DbSet<SaleNoteOfProduct>? SaleNoteOfProducts { get; set; }
        //public DbSet<SaleType>? SaleTypes { get; set; }
        //public DbSet<SupplierMoneyFlow>? SupplierMoneyFlows { get; set; }


        //public DbSet<Supplier>? Suppliers { get; set; }
        //public DbSet<SupplierFirmType>? SupplierFirmTypes { get; set; }
        //public DbSet<User>? Users { get; set; }
        //public DbSet<UserBranchAuthority>? UserBranchAuthorities { get; set; }



        //public DbSet<WorkType>? WorkTypes { get; set; }
        //public DbSet<RawMaterialOfProduct>? RawMaterialOfProducts { get; set; }
        //public DbSet<RawMaterialOfSupplier>? RawMaterialOfSuppliers { get; set; }
        //public DbSet<SaleDetail>? SaleDetails { get; set; }
        #endregion

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