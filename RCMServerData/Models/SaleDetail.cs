using RCMServerData.BaseModels;
using System;

namespace RCMServerData.Models
{
    public class SaleDetail : BaseDomain
    {
        public SaleDetail()
        {
            this.Users = new HashSet<User>();
            this.Products = new HashSet<Product>();
        }

        public Guid Id { get; set; }
        public long SId { get; set; }
        public short PId { get; set; }
        public decimal Price { get; set; }
        public short Qty { get; set; }
        public decimal Portion { get; set; }
        public decimal Total { get; set; }
        public string? Note { get; set; }
        public decimal? CutOff { get; set; }
        public bool IsActive { get; set; }

        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }


        public Sale? Sale { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
