using RCMServerData.BaseModels;
using System.Collections.Generic;

namespace RCMServerData.Models
{
    public class ConsumeType : BaseDomain
    {
        public ConsumeType()
        {
            this.BranchConsumptions = new HashSet<BranchConsumption>();
        }

        public byte ConsTId { get; set; }
        public string? Type { get; set; }

        public virtual ICollection<BranchConsumption> BranchConsumptions { get; set; }
    }
}
