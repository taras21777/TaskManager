using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://localhost:41447/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this.Loaded += MainWindow_Loaded;
        }

        async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            HttpResponseMessage response = await client.GetAsync("api/tasklists");
            response.EnsureSuccessStatusCode(); // Throw on error code.
            var reports = await response.Content.ReadAsAsync<IEnumerable<Tasklist>>();
            TaskListGrid.ItemsSource = reports;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void DeleteTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectedTask tl = TaskGrid.SelectedItems[0] as SelectedTask;
                HttpResponseMessage response = await client.DeleteAsync("/api/tasks/" + tl.TaskId);
                response.EnsureSuccessStatusCode(); // Throw on error code.
                MessageBox.Show("Task Successfully Deleted");
              
                TaskGrid.ScrollIntoView(TaskGrid.ItemContainerGenerator.Items[TaskGrid.Items.Count - 1]);
            }
            catch (Exception)
            {
                MessageBox.Show("Task Deletion Unsuccessful");
            }
        }

        private async void DeleteTaskListBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Tasklist tl = TaskListGrid.SelectedItems[0] as Tasklist;
                
                HttpResponseMessage response = await client.DeleteAsync("/api/tasklists/" + tl.Id);
                response.EnsureSuccessStatusCode(); // Throw on error code.
                MessageBox.Show("Tasklist Successfully Deleted");
                
                TaskListGrid.ItemsSource = await GetAllTasklists();
                TaskListGrid.ScrollIntoView(TaskListGrid.ItemContainerGenerator.Items[TaskListGrid.Items.Count - 1]);
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Tasklist Deletion Unsuccessful" + ex.ToString());
            }
        }

        public async Task<IEnumerable<Tasklist>> GetAllTasklists()
        {
            HttpResponseMessage response = await client.GetAsync("/api/tasklists");
            response.EnsureSuccessStatusCode(); // Throw on error code.
            var tasklist = await response.Content.ReadAsAsync<IEnumerable<Tasklist>>();
            return tasklist;
        }
        
        public async Task<IEnumerable<Tasks>> GetAllTasks()
        {
            HttpResponseMessage response = await client.GetAsync("/api/tasks/");
            response.EnsureSuccessStatusCode(); // Throw on error code.
            var tasks = await response.Content.ReadAsAsync<IEnumerable<Tasks>>();
            return tasks;
        }

        public async Task<IEnumerable<TaskStatuses>> GetAllTaskStatusess()
        {
            HttpResponseMessage response = await client.GetAsync("/api/taskstatus/");
            response.EnsureSuccessStatusCode(); // Throw on error code.
            var taskstatus = await response.Content.ReadAsAsync<IEnumerable<TaskStatuses>>();
            return taskstatus;
        }

        private async void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow td = sender as DataGridRow;
            Tasklist tl = td.Item as Tasklist;
            List<Tasks> task = await GetAllTasks() as List<Tasks>;
            // MessageBox.Show(task.ToString());
            var taskstatus = await GetAllTaskStatusess();
            var SelectTask = from t in task
                             join ts in taskstatus on t.TaskStatusId equals ts.TaskStatusId
                             where t.TaskListId == tl.Id
                             select  new SelectedTask { TaskId = t.TaskId, Name = t.Name, Status = ts.Name };
           
           
            TaskGrid.ItemsSource = SelectTask;
        }

        private void Row_Click(object sender, MouseButtonEventArgs e)
        {
            DataGridRow td = sender as DataGridRow;
            SelectedTask tl = td.Item as SelectedTask;
            StatusCmbB.Items.Clear();
            StatusCmbB.Items.Add("Open");
            StatusCmbB.Items.Add("Closed");
            NametxtB.Text = tl.Name;
            switch (tl.Status)
            {
                case "Open":
                    {
                        StatusCmbB.SelectedIndex = 0;
                        break;
                    }
                case "Closed":
                    {
                        StatusCmbB.SelectedIndex = 1;
                        break;
                    }
            }

        }

        private async void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                SelectedTask tl = TaskGrid.SelectedItems[0] as SelectedTask;
                tl.Name = NametxtB.Text;
                tl.Status = StatusCmbB.SelectedItem.ToString();
                HttpResponseMessage response = await client.GetAsync("/api/tasks/"+tl.TaskId);
                Tasks tasks = await response.Content.ReadAsAsync<Tasks>();
                tasks.Name = NametxtB.Text;
                switch(StatusCmbB.SelectedItem.ToString())
                {
                    case "Open":
                        {
                            tasks.TaskStatusId = 1;
                            break;
                        }
                    case "Closed":
                        {
                            tasks.TaskStatusId = 2;
                            break;
                        }
                }
                HttpResponseMessage response1 = await client.PutAsJsonAsync("/api/tasks/"+tasks.TaskId,tasks);
                response1.EnsureSuccessStatusCode(); // Throw on error code.
            }
            catch (Exception)
            {
                MessageBox.Show("Task Edit Unsuccessful");
            }
        }
    }
}
