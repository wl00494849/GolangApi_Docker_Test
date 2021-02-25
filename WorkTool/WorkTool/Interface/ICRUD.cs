using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTool.Models.DataModel;

namespace WorkTool.Interface
{
    public interface ICRUD<T>
    {
        public List<T> GetList ();
        public void Create(T work);
        public void Delete(string primarykey);
        public T Detail(string primarykey);
    }
}
