using RCMServerData.BaseModels;
using System;
using System.Collections.Generic;

namespace RCMServerData.Models
{
    public class Product : BaseDomain
    {
        public Product()
        {
            this.BranchProductPrices = new HashSet<BranchProductPrice>();
            //this.Products = new HashSet<Product>();
            //this.ProductPhotos = new HashSet<ProductPhoto>();
            //this.RawMaterialOfProducts = new HashSet<RawMaterialOfProduct>();
            this.SaleDetails = new HashSet<SaleDetail>();
            //this.SaleNoteOfProducts = new HashSet<SaleNoteOfProduct>();
        }

        public short Id { get; set; }
        public string? Name { get; set; }
        public short CatId { get; set; }
        public decimal? Price { get; set; }
        public decimal? VATpercent { get; set; }
        //public short? TopPId { get; set; }
        public bool IsActive { get; set; }

        public ICollection<BranchProductPrice> BranchProductPrices { get; set; }
        //public ICollection<Product> Products { get; set; }
        //public Product? TopProduct { get; set; }
        //public ICollection<Product> SubProducts { get; set; }
        public ProductCategory? ProductCategory { get; set; }
        //public ICollection<ProductPhoto> ProductPhotos { get; set; }
        //public ICollection<RawMaterialOfProduct> RawMaterialOfProducts { get; set; }
        public ICollection<SaleDetail> SaleDetails { get; set; }
        //public ICollection<SaleNoteOfProduct> SaleNoteOfProducts { get; set; }
    }
}
