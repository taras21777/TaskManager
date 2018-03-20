using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class TaskListsController : ApiController
    {
        public TaskContext db = new TaskContext();
        public IEnumerable<TaskList> GetTaskLists()
        {
            return db.TaskLists;
        }

        public TaskList GetTaskList(int id)
        {
            TaskList tasklist = db.TaskLists.Find(id);
            return tasklist;
        }

        [HttpPost]
        public void CreateTaskList([FromBody]TaskList tasklist)
        {
            try
            {
                db.TaskLists.Add(tasklist);
                db.SaveChanges();
            }
                catch (Exception ex)
            {
                string k = ex.Message;
            }
        }

        [HttpPut]
        public void EditTaskList(int id, [FromBody]TaskList tasklist)
        {
            if (id == tasklist.Id)
            {
                db.Entry(tasklist).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        public void DeleteTaskList(int id)
        {
            TaskList tasklist = db.TaskLists.Find(id);
            if (tasklist != null)
            {
                db.TaskLists.Remove(tasklist);
                db.SaveChanges();
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}