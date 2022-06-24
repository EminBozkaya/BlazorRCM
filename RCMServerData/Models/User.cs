using RCMServerData.BaseModels;
using System;
using System.Collections.Generic;

namespace RCMServerData.Models
{
    public class User : BaseDomain
    {
        public User()
        {
            //this.BranchCaseTypes = new HashSet<BranchCaseType>();
            //this.BranchCaseTypeFlows = new HashSet<BranchCaseTypeFlow>();
            //this.BranchConsumptions = new HashSet<BranchConsumption>();
            //this.BranchCreditCards = new HashSet<BranchCreditCard>();
            //this.BranchCreditCardFlows = new HashSet<BranchCreditCardFlow>();
            //this.BranchRevenueDistributions = new HashSet<BranchRevenueDistribution>();
            //this.BranchStocks = new HashSet<BranchStock>();
            //this.BranchStockEntries = new HashSet<BranchStockEntry>();
            //this.EmployeeMoneyFlows = new HashSet<EmployeeMoneyFlow>();
            //this.EmployeeRollCalls = new HashSet<EmployeeRollCall>();
            //this.ExpenseFlows = new HashSet<ExpenseFlow>();
            //this.ExpenseFlows1 = new HashSet<ExpenseFlow>();
            this.Sales = new HashSet<Sale>();
            this.SalesMB = new HashSet<Sale>();
            this.SalesDB = new HashSet<Sale>();
            this.SaleDetailsMB = new HashSet<SaleDetail>();
            this.SuppliersCB = new HashSet<Supplier>();
            this.SuppliersMB = new HashSet<Supplier>();
            //this.SupplierMoneyFlows = new HashSet<SupplierMoneyFlow>();
            this.UserBranchAuthorities = new HashSet<UserBranchAuthority>();
            this.BranchSuppliersCB = new HashSet<BranchSupplier>();
            this.BranchSuppliersMB = new HashSet<BranchSupplier>();
            this.SupplierFirmTypesCB = new HashSet<SupplierFirmType>();
            this.SupplierFirmTypesMB = new HashSet<SupplierFirmType>();
        }

        public int Id { get; set; }        
        public string? FirstName { get; set; }    
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        //public String? FullName => $"{FirstName} {LastName}";
        //public String? FullName
        //{
        //    get
        //    {
        //        return $"{FirstName} {LastName}";
        //    }
        //    set { }
        //}
        //public virtual ICollection<BranchCaseType> BranchCaseTypes { get; set; }
        //public virtual ICollection<BranchCaseTypeFlow> BranchCaseTypeFlows { get; set; }
        //public virtual ICollection<BranchConsumption> BranchConsumptions { get; set; }
        //public virtual ICollection<BranchCreditCard> BranchCreditCards { get; set; }
        //public virtual ICollection<BranchCreditCardFlow> BranchCreditCardFlows { get; set; }
        //public virtual ICollection<BranchRevenueDistribution> BranchRevenueDistributions { get; set; }
        //public virtual ICollection<BranchStock> BranchStocks { get; set; }
        //public virtual ICollection<BranchStockEntry> BranchStockEntries { get; set; }
        //public virtual ICollection<EmployeeMoneyFlow> EmployeeMoneyFlows { get; set; }
        //public virtual ICollection<EmployeeRollCall> EmployeeRollCalls { get; set; }
        //public virtual ICollection<ExpenseFlow> ExpenseFlows { get; set; }
        //public virtual ICollection<ExpenseFlow> ExpenseFlows1 { get; set; }

        public ICollection<Sale> Sales { get; set; }
        public ICollection<Sale> SalesMB { get; set; }
        public ICollection<Sale> SalesDB { get; set; }
        public ICollection<SaleDetail> SaleDetailsMB { get; set; }
        public ICollection<Supplier> SuppliersCB { get; set; }
        public ICollection<Supplier> SuppliersMB { get; set; }
        //public virtual ICollection<SupplierMoneyFlow> SupplierMoneyFlows { get; set; }
        public ICollection<UserBranchAuthority> UserBranchAuthorities { get; set; }
        public ICollection<BranchSupplier> BranchSuppliersCB { get; set; }
        public ICollection<BranchSupplier> BranchSuppliersMB { get; set; }
        public ICollection<SupplierFirmType> SupplierFirmTypesCB { get; set; }
        public ICollection<SupplierFirmType> SupplierFirmTypesMB { get; set; }
    }
}
