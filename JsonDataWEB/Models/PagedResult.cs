using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonDataWEB.Models
{
    public class PagedResult<TResult> 
    {
        public int TotalCount { get; set; }
        public List<TResult> Result { get; set; }
    }
}