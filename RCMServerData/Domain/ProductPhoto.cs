using Core.Model;
using System;

namespace RCMServerData.Domain
{
    public class ProductPhoto : BaseDomain
    {
        public int Id { get; set; }
        public Nullable<short> PId { get; set; }
        public string PhotoPath { get; set; }
        public Nullable<bool> IsActive { get; set; }

        public virtual Product Product { get; set; }
    }
}
