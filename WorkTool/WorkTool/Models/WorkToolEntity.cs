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
        public WorkToolEntity(DbContextOptions<WorkToolEntity> options) : base(options)
        {

        }
        public DbSet<Work> Works { get; set; }
    }
}
