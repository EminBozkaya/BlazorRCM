using Core.Model;
using System;
using System.Collections.Generic;

namespace RCMServerData.Domain
{
    public class User : BaseDomain
    {
        public User()
        {
            this.BranchCaseTypes = new HashSet<BranchCaseType>();
            this.BranchCaseTypeFlows = new HashSet<BranchCaseTypeFlow>();
            this.BranchConsumptions = new HashSet<BranchConsumption>();
            this.BranchCreditCards = new HashSet<BranchCreditCard>();
            this.BranchCreditCardFlows = new HashSet<BranchCreditCardFlow>();
            this.BranchRevenueDistributions = new HashSet<BranchRevenueDistribution>();
            this.BranchStocks = new HashSet<BranchStock>();
            this.BranchStockEntries = new HashSet<BranchStockEntry>();
            this.EmployeeMoneyFlows = new HashSet<EmployeeMoneyFlow>();
            this.EmployeeRollCalls = new HashSet<EmployeeRollCall>();
            this.ExpenseFlows = new HashSet<ExpenseFlow>();
            this.ExpenseFlows1 = new HashSet<ExpenseFlow>();
            this.Sales = new HashSet<Sale>();
            this.SaleDetails = new HashSet<SaleDetail>();
            this.Suppliers = new HashSet<Supplier>();
            this.SupplierMoneyFlows = new HashSet<SupplierMoneyFlow>();
            this.UserBranchAuthorities = new HashSet<UserBranchAuthority>();
        }

        public int UId { get; set; }        
        public string FirstName { get; set; }    
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public Nullable<System.DateTime> ModifiedTime { get; set; }

        public virtual ICollection<BranchCaseType> BranchCaseTypes { get; set; }
        public virtual ICollection<BranchCaseTypeFlow> BranchCaseTypeFlows { get; set; }
        public virtual ICollection<BranchConsumption> BranchConsumptions { get; set; }
        public virtual ICollection<BranchCreditCard> BranchCreditCards { get; set; }
        public virtual ICollection<BranchCreditCardFlow> BranchCreditCardFlows { get; set; }
        public virtual ICollection<BranchRevenueDistribution> BranchRevenueDistributions { get; set; }
        public virtual ICollection<BranchStock> BranchStocks { get; set; }
        public virtual ICollection<BranchStockEntry> BranchStockEntries { get; set; }
        public virtual ICollection<EmployeeMoneyFlow> EmployeeMoneyFlows { get; set; }
        public virtual ICollection<EmployeeRollCall> EmployeeRollCalls { get; set; }
        public virtual ICollection<ExpenseFlow> ExpenseFlows { get; set; }
        public virtual ICollection<ExpenseFlow> ExpenseFlows1 { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
        public virtual ICollection<SupplierMoneyFlow> SupplierMoneyFlows { get; set; }
        public virtual ICollection<UserBranchAuthority> UserBranchAuthorities { get; set; }
    }
}
