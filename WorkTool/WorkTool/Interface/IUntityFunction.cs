using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkTool.Interface
{
    public interface IUntityFunction
    {
        public string AutoProduceID<T>(string dataType,IEnumerable<T> dataTable);
    }
}
