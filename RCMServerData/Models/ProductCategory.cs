using RCMServerData.BaseModels;
using System.Collections.Generic;

namespace RCMServerData.Models
{
    public class ProductCategory : BaseDomain
    {
        public ProductCategory()
        {
            this.Products = new HashSet<Product>();
            this.SubProductCategories = new HashSet<ProductCategory>();
        }

        public short Id { get; set; }
        public string? Name { get; set; }
        public short? TopCatId { get; set; }
        public bool IsActive { get; set; }


        public ProductCategory? TopProductCategory { get; set; }
        public ICollection<ProductCategory> SubProductCategories { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
