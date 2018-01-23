using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PlannerApp
{
    class TaskContext : DbContext
    {
        public TaskContext()
            : base("DbConnection")
        { }

        public DbSet<Task> Tasks { get; set; }
    }
}