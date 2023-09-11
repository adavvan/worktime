using Microsoft.EntityFrameworkCore;
using MVVVM.Worktime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Worktime.Data
{
    public class WorktimeContext : DbContext
    {
        public DbSet<WorkTask> WorkTasks { get; set; } = null!;
        public DbSet<Worker> Workers { get; set; } = null!;
        public DbSet<Activity> Activities { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=worktime;Trusted_Connection=True;");
        }
    }
}
