﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRCM.Shared.ResponseModels
{
    public class ServiceResponse<T> : BaseResponse
    {
        public T? Value { get; set; }
        //public List<T>? Values { get; set; }
        //public string[]? K { get; set; }
    }
}
