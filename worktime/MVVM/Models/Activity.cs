using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVVM.Worktime.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
    }
}
