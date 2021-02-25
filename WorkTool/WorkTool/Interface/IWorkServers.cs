using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTool.Models.DataModel;

namespace WorkTool.Interface
{
    public interface IWorkServers
    {
        public List<Work> GetWorkList ();
    }
}
