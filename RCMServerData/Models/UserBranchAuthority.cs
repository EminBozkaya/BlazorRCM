using RCMServerData.BaseModels;

namespace RCMServerData.Models
{
    public class UserBranchAuthority : BaseDomain
    {
        public int Id { get; set; }
        public int UId { get; set; }
        public short BId { get; set; }
        public short ATId { get; set; }
        public bool IsActive { get; set; }

        public AuthorityType? AuthorityType { get; set; }
        public Branch? Branch { get; set; }
        public User? User { get; set; }
    }
}
