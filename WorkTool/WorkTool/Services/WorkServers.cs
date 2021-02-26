using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTool.Models;
using WorkTool.Models.DataModel;
using WorkTool.Interface;

namespace WorkTool.Services
{
    public class WorkServers : IWork
    {
        WorkToolEntity _db;
        IUntityFunction _untity;
        public WorkServers(WorkToolEntity db, IUntityFunction untity)
        {
            _db = db;
            _untity = untity;
        }
        public List<Work> GetList()
        {
            var dataList = _db.Work.ToList();
            return dataList;
        }
        public void Create(Work work)
        {
            work.WorkID = string.IsNullOrWhiteSpace(work.WorkID) ? _untity.AutoProduceID(_db.Work, "WorkID") : work.WorkID;
            work.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            _db.Add(work);
            _db.SaveChanges();
        }

        public void Delete(string workID)
        {
            var target = _db.Work.Where(m => m.WorkID == workID).FirstOrDefault();
            _db.Remove(target);
            _db.SaveChanges();
        }

        public Work Detail(string workID)
        {
            var data = _db.Work.Where(m => m.WorkID == workID).FirstOrDefault();
            return data;
        }
    }
}
