using Core.Model;
using System.Collections.Generic;

namespace RCMServerData.Domain
{
    public class ExpenseType : BaseDomain
    {
        public ExpenseType()
        {
            this.ExpenseFlows = new HashSet<ExpenseFlow>();
        }

        public byte ExId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ExpenseFlow> ExpenseFlows { get; set; }
    }
}
