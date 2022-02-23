using Core.Model;
using System.Collections.Generic;

namespace RCMServerData.Models
{
    public class SalaryType : BaseDomain
    {
        public SalaryType()
        {
            this.Employees = new HashSet<Employee>();
        }

        public byte Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
