using RCMServerData.BaseModels;
using System.Collections.Generic;

namespace RCMServerData.Models
{
    public class EmployeePaymentType : BaseDomain
    {
        public EmployeePaymentType()
        {
            this.EmployeeMoneyFlows = new HashSet<EmployeeMoneyFlow>();
        }

        public byte EPTId { get; set; }
        public string? Type { get; set; }

        public virtual ICollection<EmployeeMoneyFlow> EmployeeMoneyFlows { get; set; }
    }
}
