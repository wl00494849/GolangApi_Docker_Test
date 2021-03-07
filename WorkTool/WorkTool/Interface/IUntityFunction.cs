using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WorkTool.Interface
{
    public interface IUntityFunction
    {
        public string AutoProduceID<T>(IEnumerable<T> dataTable,string primarykey);
        public void Upload(IFormFile file);
    }
}
