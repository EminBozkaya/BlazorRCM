using Core.Model;
using System.Collections.Generic;

namespace RCMServerData.Domain
{
    public class AuthorityType : BaseDomain
    {
        
        public AuthorityType()
        {
            this.UserBranchAuthorities = new HashSet<UserBranchAuthority>();
        }

        public byte ATId { get; set; }
        public string Type { get; set; }

        
        public virtual ICollection<UserBranchAuthority> UserBranchAuthorities { get; set; }
    }
}
