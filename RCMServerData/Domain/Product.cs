using Core.Model;
using System;
using System.Collections.Generic;

namespace RCMServerData.Domain
{
    public class Product : BaseDomain
    {
        public Product()
        {
            this.BranchProductPrices = new HashSet<BranchProductPrice>();
            this.Product1 = new HashSet<Product>();
            this.ProductPhotoes = new HashSet<ProductPhoto>();
            this.RawMaterialOfProducts = new HashSet<RawMaterialOfProduct>();
            this.SaleDetails = new HashSet<SaleDetail>();
            this.SaleNoteOfProducts = new HashSet<SaleNoteOfProduct>();
        }

        public short PId { get; set; }
        public string Name { get; set; }
        public byte CatId { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<double> VATpercent { get; set; }
        public Nullable<short> TopPId { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BranchProductPrice> BranchProductPrices { get; set; }
        public virtual ICollection<Product> Product1 { get; set; }
        public virtual Product Product2 { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<ProductPhoto> ProductPhotoes { get; set; }
        public virtual ICollection<RawMaterialOfProduct> RawMaterialOfProducts { get; set; }
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
        public virtual ICollection<SaleNoteOfProduct> SaleNoteOfProducts { get; set; }
    }
}
