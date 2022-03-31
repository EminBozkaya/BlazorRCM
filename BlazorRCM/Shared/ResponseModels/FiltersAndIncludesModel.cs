using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRCM.Shared.ResponseModels
{
    public class FiltersAndIncludesModel<TEntityDTO>
    {
        public string? filter { get; set; }
        //public Expression<Func<TEntityDTO, bool>>? filter { get; set; }
        public string[]? includeList { get; set; }
    }
}
