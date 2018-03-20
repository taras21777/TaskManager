using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class TaskList
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime DateCreate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime DueCreate { get; set; }

    }
}