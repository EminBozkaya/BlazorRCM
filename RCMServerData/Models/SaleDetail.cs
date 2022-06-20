using RCMServerData.BaseModels;
using System;

namespace RCMServerData.Models
{
    public class SaleDetail : BaseDomain
    {
        //public SaleDetail()
        //{
        //    this.Users = new HashSet<User>();
        //    this.Products = new HashSet<Product>();
        //}

        public Guid Id { get; set; }
        public int SId { get; set; }
        public short? BillOrder { get; set; }
        public short PId { get; set; }
        public decimal Price { get; set; }
        public decimal Portion { get; set; }
        public short Qty { get; set; }
        public decimal Total { get; set; }
        public string? Note { get; set; }
        public string? generalProductNote { get; set; }
        public string? firstProductNote { get; set; }
        public string? secondProductNote { get; set; }
        public string? thirdProductNote { get; set; }
        //public decimal? CutOff { get; set; }
        public bool IsActive { get; set; }

        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }


        public Sale? Sale { get; set; }
        public Product? Product { get; set; }
        public User? UserMB { get; set; }
        //public ICollection<Product> Products { get; set; }
        //public ICollection<User> Users { get; set; }
    }
}
