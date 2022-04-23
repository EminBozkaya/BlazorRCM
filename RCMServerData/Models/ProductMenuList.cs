using RCMServerData.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCMServerData.Models
{
    public class ProductMenuList: BaseDomain
    {
        public ProductMenuList()
        {
            this.Products = new HashSet<Product>();
        }
        public short Id { get; set; }
        public string? ListName { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
