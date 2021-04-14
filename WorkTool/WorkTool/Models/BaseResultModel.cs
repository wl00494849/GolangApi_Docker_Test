using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkTool.Models
{
    public class BaseResultModel<T>
    {
        Enum.Response _response;
        public T body { get; set; }
        public string message => _response.ToString();
        public string code => Convert.ToInt32(_response).ToString().PadLeft(3, '0');
        public Enum.Response response { set { _response = value; } get { return _response; } }
        public string exception { get; set; }
    }
}
