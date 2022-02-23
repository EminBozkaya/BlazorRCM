using Core.Model;
using System.Collections.Generic;

namespace RCMServerData.Models
{
    public class Customer : BaseDomain
    {
        public Customer()
        {
            this.AdressOfCustomers = new HashSet<AdressOfCustomer>();
            this.Sales = new HashSet<Sale>();
        }

        public int CId { get; set; }
        public short BId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string PrivateNote { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<AdressOfCustomer> AdressOfCustomers { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
