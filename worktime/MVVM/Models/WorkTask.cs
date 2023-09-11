using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVVM.Worktime.Models
{
    public class WorkTask
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int WorkHour { get; set; }
        public int WorkMin { get; set; }
        public string? Description { get; set; }

        [ForeignKey("WorkerId")]
        public Worker Worker { get; set; } = null!;

        [ForeignKey("ActivityId")]
        public Activity Activity { get; set; } = null!;
    }
}
