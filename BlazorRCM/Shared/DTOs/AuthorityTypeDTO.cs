using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRCM.Shared.DTOs
{
    public class AuthorityTypeDTO : BaseDTO
    {
        public short Id { get; set; }
        public string? Type { get; set; }
    }
}
