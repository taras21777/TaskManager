using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFmvvm.Model
{
    public class Tasks : HttpRepository<Tasks>
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public int TaskStatusId { get; set; }
        public int TaskListId { get; set; }

        public Tasks() { }
        public Tasks(int id, string name, int stid, int tlid)
        {
            this.TaskId = id;
            this.Name = name;
            this.TaskStatusId = stid;
            this.TaskListId = tlid;
        }

        public Tasks(string name, int stid, int tlid)
        {
            this.Name = name;
            this.TaskStatusId = stid;
            this.TaskListId = tlid;
        }

        HttpClient client = new HttpClient();


        public override async Task<IEnumerable<Tasks>> GetAll()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:41447//api/tasks/");

            response.EnsureSuccessStatusCode(); // Throw on error code.
            var tasks = await response.Content.ReadAsAsync<IEnumerable<Tasks>>();
            return tasks;
        }

        public  override async void AddNew(Tasks t)
        {
            HttpResponseMessage r = await client.PostAsJsonAsync("http://localhost:41447/api/tasks/", t);
            r.EnsureSuccessStatusCode();
        }

        public override async void DeleteSelected(Tasks t)
        {
            try
            {
               
                HttpResponseMessage response = await client.DeleteAsync("http://localhost:41447/api/tasks/" + t.TaskId);
                response.EnsureSuccessStatusCode(); // Throw on error code.
                MessageBox.Show("Task Successfully Deleted");
            }
            catch (Exception)
            {
                MessageBox.Show("Task Deletion Unsuccessful");
            }
        }
    }
}
