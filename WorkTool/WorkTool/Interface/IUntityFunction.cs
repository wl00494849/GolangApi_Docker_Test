using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkTool.Interface
{
    public interface IUntityFunction
    {
        public string AutoProduceID<T>(IEnumerable<T> dataTable,string primarykey);
    }
}
