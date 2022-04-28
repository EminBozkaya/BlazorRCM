using RCMServerData.BaseModels;
using System.Collections.Generic;

namespace RCMServerData.Models
{
    public class ProductSaleNote : BaseDomain
    {
        //public SaleNote()
        //{
        //    this.SaleNoteOfProducts = new HashSet<SaleNoteOfProduct>();
        //}

        public short Id { get; set; }
        public string? Definition { get; set; }
        public short? NoteCat { get; set; }
        public ProductSaleNoteCategory? ProductSaleNoteCategory { get; set; }
        //    public virtual ICollection<SaleNoteOfProduct> SaleNoteOfProducts { get; set; }
    }
}
