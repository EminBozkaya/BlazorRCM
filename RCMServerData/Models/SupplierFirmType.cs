using Core.Model;
using System;
using System.Collections.Generic;

namespace RCMServerData.Models
{
    public class SupplierFirmType : BaseDomain
    {
        public int Id { get; set; }
        public int SpId { get; set; }
        public short FtId { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public bool IsActive { get; set; }

        public Supplier? Supplier { get; set; }
        public FirmType? FirmType { get; set; }
        public User? User { get; set; }
        
    }
}
