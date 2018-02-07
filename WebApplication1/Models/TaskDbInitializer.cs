using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class TaskDbInitializer : DropCreateDatabaseAlways<TaskContext>
    {
        protected override void Seed(TaskContext db)
        {
            DateTime hiredateBoss = new DateTime(1991, 12, 31);
            DateTime hiredateBoss1 = new DateTime(1992, 12, 31);
            // создание и добавление моделей
            TaskStatus ts1 = new TaskStatus { Name = "Open" };
            TaskStatus ts2 = new TaskStatus { Name = "Closed" };
            db.TaskStatus.Add(ts1);
            db.TaskStatus.Add(ts2);
            db.SaveChanges();
            TaskList t1 = new TaskList { Name = "TaskList1", DateCreate = hiredateBoss, DueCreate = hiredateBoss1 };
            TaskList t2 = new TaskList { Name = "TaskList2", DateCreate = hiredateBoss, DueCreate = hiredateBoss1 };
            db.TaskLists.Add(t1);
            db.TaskLists.Add(t2);
            db.SaveChanges();
            Task pl1 = new Task { Name = "Task11",  TaskStatusId = ts1.TaskStatusId,  TaskListId= t2.Id };
            Task pl2 = new Task { Name = "Task22",  TaskStatusId = ts2.TaskStatusId,  TaskListId = t1.Id};
            Task pl3 = new Task { Name = "Task33",  TaskStatusId = ts1.TaskStatusId,  TaskListId = t1.Id };
            db.Tasks.AddRange(new List<Task> { pl1, pl2, pl3 });
            db.SaveChanges();
        }
    }
}