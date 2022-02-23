using Core.Model;

namespace RCMServerData.Models
{
    public class AdressOfCustomer : BaseDomain
    {
        
        public int Id { get; set; }
        public int CId { get; set; }
        public string AdressName { get; set; }
        public string Adress { get; set; }
        public string Ev { get; set; } 


        public virtual Customer Customer { get; set; }
    }
}
