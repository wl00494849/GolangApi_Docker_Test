using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkTool.Models
{
    public class BaseResultModel<T>
    {
        public T body { get; set; }
        public string message { get; set; }
        public string exception { get; set; }
    }
}
