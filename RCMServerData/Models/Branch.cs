using Core.Model;
using System;
using System.Collections.Generic;

namespace RCMServerData.Models
{
    public class Branch : BaseDomain
    {
        public Branch()
        {
            //this.BranchCaseTypes = new HashSet<BranchCaseType>();
            //this.BranchCaseTypeFlows = new HashSet<BranchCaseTypeFlow>();
            //this.BranchConsumptions = new HashSet<BranchConsumption>();
            //this.BranchCreditCards = new HashSet<BranchCreditCard>();
            //this.BranchCreditCardFlows = new HashSet<BranchCreditCardFlow>();
            //this.BranchDailyRevenues = new HashSet<BranchDailyRevenue>();
            //this.BranchProductPrices = new HashSet<BranchProductPrice>();
            //this.BranchRevenueDistributions = new HashSet<BranchRevenueDistribution>();
            //this.BranchStocks = new HashSet<BranchStock>();
            //this.BranchStockEntries = new HashSet<BranchStockEntry>();
            //this.EmployeeMoneyFlows = new HashSet<EmployeeMoneyFlow>();
            //this.EmployeeRollCalls = new HashSet<EmployeeRollCall>();
            //this.ExpenseFlows = new HashSet<ExpenseFlow>();
            //this.Sales = new HashSet<Sale>();
            this.BranchSuppliers = new HashSet<BranchSupplier>();
            //this.SupplierMoneyFlows = new HashSet<SupplierMoneyFlow>();
            this.UserBranchAuthorities = new HashSet<UserBranchAuthority>();
        }

        public short Id { get; set; }
        public string? Name { get; set; }
        public string? Adress { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }


        //public virtual ICollection<BranchCaseType> BranchCaseTypes { get; set; }
        //public virtual ICollection<BranchCaseTypeFlow> BranchCaseTypeFlows { get; set; }
        //public virtual ICollection<BranchConsumption> BranchConsumptions { get; set; }
        //public virtual ICollection<BranchCreditCard> BranchCreditCards { get; set; }
        //public virtual ICollection<BranchCreditCardFlow> BranchCreditCardFlows { get; set; }
        //public virtual ICollection<BranchDailyRevenue> BranchDailyRevenues { get; set; }
        //public virtual ICollection<BranchProductPrice> BranchProductPrices { get; set; }
        //public virtual ICollection<BranchRevenueDistribution> BranchRevenueDistributions { get; set; }
        //public virtual ICollection<BranchStock> BranchStocks { get; set; }
        //public virtual ICollection<BranchStockEntry> BranchStockEntries { get; set; }
        //public virtual ICollection<EmployeeMoneyFlow> EmployeeMoneyFlows { get; set; }
        //public virtual ICollection<EmployeeRollCall> EmployeeRollCalls { get; set; }
        //public virtual ICollection<ExpenseFlow> ExpenseFlows { get; set; }
        //public virtual ICollection<Sale> Sales { get; set; }
        public ICollection<BranchSupplier> BranchSuppliers { get; set; }
        //public virtual ICollection<SupplierMoneyFlow> SupplierMoneyFlows { get; set; }
        public ICollection<UserBranchAuthority> UserBranchAuthorities { get; set; }
    }
}
