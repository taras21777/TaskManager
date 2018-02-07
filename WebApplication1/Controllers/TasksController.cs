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
    public class TasksController : ApiController
    {
        public TaskContext db = new TaskContext();
        public IEnumerable<Task> GetTasks()
        {
            return db.Tasks;
        }

        public Task GetTask(int id)
        {
            Task task = db.Tasks.Find(id);
            return task;
        }

        [HttpPost]
        public void CreateTask([FromBody]Task task)
        {
            db.Tasks.Add(task);
            db.SaveChanges();
        }

        [HttpPut]
        public void EditTask(int id, [FromBody]Task task)
        {
            if (id == task.TaskId)
            {
                db.Entry(task).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        public void DeleteTask(int id)
        {
            Task task = db.Tasks.Find(id);
            if (task != null)
            {
                db.Tasks.Remove(task);
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