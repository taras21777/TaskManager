using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        [Required]
        public int TaskStatusId { get; set; }
        public TaskStatus TaskStatus { get; set; }
        [Required]
        public int TaskListId { get; set; }
        public TaskList TaskList { get; set; }
    }
}