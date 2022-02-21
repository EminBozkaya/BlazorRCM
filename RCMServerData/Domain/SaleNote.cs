using Core.Model;
using System.Collections.Generic;

namespace RCMServerData.Domain
{
    public class SaleNote : BaseDomain
    {
        public SaleNote()
        {
            this.SaleNoteOfProducts = new HashSet<SaleNoteOfProduct>();
        }

        public byte NoteId { get; set; }
        public string Definition { get; set; }
        public virtual SaleNoteCategory SaleNoteCategory { get; set; }
        public virtual ICollection<SaleNoteOfProduct> SaleNoteOfProducts { get; set; }
    }
}
