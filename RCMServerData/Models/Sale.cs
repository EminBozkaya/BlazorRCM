using Core.Model;
using System;
using System.Collections.Generic;

namespace RCMServerData.Models
{
    public class Sale : BaseDomain
    {
        public Sale()
        {
            this.SaleDetails = new HashSet<SaleDetail>();
        }

        public int SId { get; set; }
        public short BId { get; set; }
        public byte STId { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<byte> CTId { get; set; }
        public int UId { get; set; }
        public Nullable<int> CId { get; set; }
        public string SaleNote { get; set; }
        public string IpAdress { get; set; }
        public bool IsEOD { get; set; }
        public Nullable<System.DateTime> EOD { get; set; }
        public bool IsActive { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual CaseType CaseType { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual User User { get; set; }
        public virtual SaleType SaleType { get; set; }
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
