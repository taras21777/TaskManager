using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFmvvm.Model
{
    public class TaskList : HttpRepository<TaskList>
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DueDate { get; set; }
        private ObservableCollection<Tasks> taskListID;

        public ObservableCollection<Tasks> TaskListID
        {
            get { return taskListID; }
            set { taskListID = value; }
        }

        public TaskList(int id, string name, DateTime create, DateTime due)
        {
            this.Id = id;
            this.Name = name;
            this.CreateDate = create;
            this.DueDate = due;
        }

        public TaskList( string name, DateTime create, DateTime due)
        {
          
            this.Name = name;
            this.CreateDate = create;
            this.DueDate = due;
        }

        public TaskList() { }


        HttpClient client = new HttpClient();
       

       
        public override async Task<IEnumerable<TaskList>> GetAll()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:41447/api/tasklists");
          
            response.EnsureSuccessStatusCode(); // Throw on error code.
            var tasklist = await response.Content.ReadAsAsync<IEnumerable<TaskList>>();
            return tasklist;
        }

        public override async void AddNew(TaskList tl)
        {
            try
            {
               
                HttpResponseMessage r = await client.PostAsJsonAsync("http://localhost:41447/api/tasklists", tl);
                r.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                MessageBox.Show("Task list Adding Unsuccessful" + e.Message);
            }
        }

        public override async void DeleteSelected(TaskList t)
        {
            try
            {
                
                HttpResponseMessage response = await client.DeleteAsync("http://localhost:41447/api/tasklists/" + t.Id);
                response.EnsureSuccessStatusCode(); // Throw on error code.
                MessageBox.Show("Task list Successfully Deleted");
            }
            catch (Exception e)
            {
                MessageBox.Show("Task list Deletion Unsuccessful"+ e.Message);
            }
        }
    }
}
