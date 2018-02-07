using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class TaskStatus
    {
        public int TaskStatusId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}