using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVVM.Worktime.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
  //      public ICollection<WorkTask> WorkTasks { get; set; } = null!;
    }
}
