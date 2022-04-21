using RCMServerData.BaseModels;
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

        public int Id { get; set; }
        public short BId { get; set; }
        //public short STId { get; set; }
        public DateTime DateTime { get; set; }
        public int UId { get; set; }
        //public short? CTId { get; set; }
        //public int? CId { get; set; }
        public string? SaleNote { get; set; }
        //public string? IpAdress { get; set; }
        public bool IsEOD { get; set; }
        public DateOnly? EOD { get; set; }
        public bool IsActive { get; set; }

        public Branch? Branch { get; set; }
        //public CaseType? CaseType { get; set; }
        //public Customer? Customer { get; set; }
        public User? User { get; set; }
        //public SaleType? SaleType { get; set; }
        public ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
