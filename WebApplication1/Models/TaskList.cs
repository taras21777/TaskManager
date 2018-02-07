using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class TaskList
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DueCreate { get; set; }
    }
}