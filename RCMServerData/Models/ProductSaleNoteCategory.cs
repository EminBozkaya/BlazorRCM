using RCMServerData.BaseModels;
using System.Collections.Generic;

namespace RCMServerData.Models
{
    public class ProductSaleNoteCategory : BaseDomain
    {
        public ProductSaleNoteCategory()
        {
            this.ProductSaleNotes = new HashSet<ProductSaleNote>();
        }

        public short Id { get; set; }
        public string? NotCat { get; set; }

        public ICollection<ProductSaleNote> ProductSaleNotes{ get; set; }
    }
}
