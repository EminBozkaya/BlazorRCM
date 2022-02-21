﻿using Core.Model;

namespace RCMServerData.Domain
{
    public class UserBranchAuthority : BaseDomain
    {
        public int Id { get; set; }
        public int UId { get; set; }
        public short BId { get; set; }
        public byte ATId { get; set; }
        public bool IsActive { get; set; }

        public virtual AuthorityType AuthorityType { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual User User { get; set; }
    }
}
