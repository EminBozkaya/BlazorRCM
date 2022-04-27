using RCMServerData.BaseModels;
using System.Collections.Generic;

namespace RCMServerData.Models
{
    public class SaleNoteCategory : BaseDomain
    {
        public SaleNoteCategory()
        {
            this.SaleNotes = new HashSet<ProductSaleNote>();
        }

        public byte Id { get; set; }
        public string? NotCat { get; set; }

        public virtual ICollection<ProductSaleNote> SaleNotes { get; set; }
    }
}
