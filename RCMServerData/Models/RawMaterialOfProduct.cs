using Core.Model;

namespace RCMServerData.Models
{
    public class RawMaterialOfProduct : BaseDomain
    {
        public short PId { get; set; }
        public short RMId { get; set; }
        public double RMQty { get; set; }
        public bool IsActive { get; set; }


        public virtual Product Product { get; set; }
        public virtual RawMaterial RawMaterial { get; set; }
    }
}
