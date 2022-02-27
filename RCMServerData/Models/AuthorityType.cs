using Core.Model;
using System.Collections.Generic;

namespace RCMServerData.Models
{
    public class AuthorityType : BaseDomain
    {
        
        public AuthorityType()
        {
            this.UserBranchAuthorities = new HashSet<UserBranchAuthority>();
        }

        public short ATId { get; set; }
        public string? Type { get; set; }
        

        public virtual ICollection<UserBranchAuthority> UserBranchAuthorities { get; set; }
    }
}
