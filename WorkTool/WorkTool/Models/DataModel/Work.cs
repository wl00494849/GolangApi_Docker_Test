using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkTool.Models.DataModel
{
    public class Work
    {
        public string WorkID { get; set; }
        public string WorkName { get; set; }
        public string WorkStatus { get; set; }
        public string WorkUrgent { get; set; }
        public string WorkType { get; set; }
        public string ConSumeTime { get; set; }
        public string WorkDate { get; set; }
    }
}
