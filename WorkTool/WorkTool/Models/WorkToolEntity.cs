using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTool.Models.DataModel;
using Microsoft.EntityFrameworkCore;

namespace WorkTool.Models
{
    public class WorkToolEntity : DbContext
    {
        public WorkToolEntity(DbContextOptions options) : base(options)
        {

        }
        DbSet<Work> work { get; set; }
    }
}
