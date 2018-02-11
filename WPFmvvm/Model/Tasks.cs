using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFmvvm.Model
{
    public class Tasks
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public int TaskStatusId { get; set; }
        public int TaskListId { get; set; }
    }
}
