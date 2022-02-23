using Core.Model;
using System.Collections.Generic;

namespace RCMServerData.Models
{
    public class CaseType : BaseDomain
    {
        
        public CaseType()
        {
            this.BranchCaseTypes = new HashSet<BranchCaseType>();
            this.BranchCaseTypeFlows = new HashSet<BranchCaseTypeFlow>();
            this.BranchRevenueDistributions = new HashSet<BranchRevenueDistribution>();
            this.EmployeeMoneyFlows = new HashSet<EmployeeMoneyFlow>();
            this.ExpenseFlows = new HashSet<ExpenseFlow>();
            this.Sales = new HashSet<Sale>();
            this.SupplierMoneyFlows = new HashSet<SupplierMoneyFlow>();
        }

        public byte CTId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BranchCaseType> BranchCaseTypes { get; set; }
        public virtual ICollection<BranchCaseTypeFlow> BranchCaseTypeFlows { get; set; }
        public virtual ICollection<BranchRevenueDistribution> BranchRevenueDistributions { get; set; }
        public virtual ICollection<EmployeeMoneyFlow> EmployeeMoneyFlows { get; set; }
        public virtual ICollection<ExpenseFlow> ExpenseFlows { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<SupplierMoneyFlow> SupplierMoneyFlows { get; set; }
    }
}
