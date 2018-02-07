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
    public class TaskStatusController : ApiController
    {
        public TaskContext db = new TaskContext();
        public IEnumerable<TaskStatus> GetTaskStatuses()
        {
            return db.TaskStatus;
        }

        public TaskStatus GetTaskStatus(int id)
        {
            TaskStatus taskstatus = db.TaskStatus.Find(id);
            return taskstatus;
        }

        [HttpPost]
        public void CreateTaskStatus([FromBody]TaskStatus taskstatus)
        {
            db.TaskStatus.Add(taskstatus);
            db.SaveChanges();
        }

        [HttpPut]
        public void EditTaskStatus(int id, [FromBody]TaskStatus taskstatus)
        {
            if (id == taskstatus.TaskStatusId)
            {
                db.Entry(taskstatus).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        public void DeleteTaskStatus(int id)
        {
            TaskStatus taskstatus = db.TaskStatus.Find(id);
            if (taskstatus != null)
            {
                db.TaskStatus.Remove(taskstatus);
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