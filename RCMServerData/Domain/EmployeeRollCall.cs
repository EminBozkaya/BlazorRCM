using Core.Model;
using System;

namespace RCMServerData.Domain
{
    public class EmployeeRollCall : BaseDomain
    {
        public int Id { get; set; }
        public short BId { get; set; }
        public int UId { get; set; }
        public int RollCaledEId { get; set; }
        public byte RCTId { get; set; }
        public System.DateTime Date { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; }
        public bool IsEOD { get; set; }
        public Nullable<System.DateTime> EOD { get; set; }
        public string IpAdress { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual User User { get; set; }
        public virtual RollCallType RollCallType { get; set; }
    }
}
