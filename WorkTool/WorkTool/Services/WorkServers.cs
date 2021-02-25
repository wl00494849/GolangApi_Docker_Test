using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTool.Models;
using WorkTool.Models.DataModel;
using WorkTool.Interface;

namespace WorkTool.Services
{
    public class WorkServers : IWorkServers
    {
        WorkToolEntity _db;
        public WorkServers(WorkToolEntity db)
        {
            _db = db;
        }
        public List<Work> GetWorkList()
        {
            var dataList = _db.Work.ToList();
            return dataList;
        }
    }
}
