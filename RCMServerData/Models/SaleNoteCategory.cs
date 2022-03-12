using Core.Model;
using System.Collections.Generic;

namespace RCMServerData.Models
{
    public class SaleNoteCategory : BaseDomain
    {
        public SaleNoteCategory()
        {
            this.SaleNotes = new HashSet<SaleNote>();
        }

        public byte Id { get; set; }
        public string? NotCat { get; set; }

        public virtual ICollection<SaleNote> SaleNotes { get; set; }
    }
}
