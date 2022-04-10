using RCMServerData.BaseModels;
using System.Collections.Generic;

namespace RCMServerData.Models
{
    public class AuthorityType : BaseDomain
    {
        
        public AuthorityType()
        {
            this.UserBranchAuthorities = new HashSet<UserBranchAuthority>();
        }

        public short Id { get; set; }
        public string? Type { get; set; }
        

        public ICollection<UserBranchAuthority> UserBranchAuthorities { get; set; }
    }
}
