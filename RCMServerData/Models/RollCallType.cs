using Core.Model;
using System.Collections.Generic;

namespace RCMServerData.Models
{
    public class RollCallType : BaseDomain
    {
        public RollCallType()
        {
            this.EmployeeRollCalls = new HashSet<EmployeeRollCall>();
        }

        public byte RCTId { get; set; }
        public string? Type { get; set; }

        public virtual ICollection<EmployeeRollCall> EmployeeRollCalls { get; set; }
    }
}
