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

        private void addTaskButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void updateTaskButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteTaskButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {

        }
        //Delete Task list 
        private async void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Tasklist td = (Tasklist)TaskListGrid.SelectedItem;
                HttpResponseMessage response = await client.DeleteAsync("/api/tasklists/" + td.Id);
                response.EnsureSuccessStatusCode(); // Throw on error code.
                MessageBox.Show("Tasklist Successfully Deleted");
                TaskListGrid.ItemsSource = await GetAllTasklists();
                TaskListGrid.ScrollIntoView(TaskListGrid.ItemContainerGenerator.Items[TaskListGrid.Items.Count - 1]);
            }
            catch (Exception)
            {
                MessageBox.Show("Tasklist Deletion Unsuccessful");
            }
        }

        //Get all task lists from Web Api
        public async Task<IEnumerable<Tasklist>> GetAllTasklists()
        {
            HttpResponseMessage response = await client.GetAsync("/api/tasklists");
            response.EnsureSuccessStatusCode(); // Throw on error code.
            var tasklist = await response.Content.ReadAsAsync<IEnumerable<Tasklist>>();
            return tasklist;
        }

        //Get all tasks from Web Api
        public async Task<IEnumerable<Tasks>> GetAllTasks()
        {
            HttpResponseMessage response = await client.GetAsync("/api/tasks/");
            response.EnsureSuccessStatusCode(); // Throw on error code.
            var tasks = await response.Content.ReadAsAsync<IEnumerable<Tasks>>();
            return tasks;
        }

        //Get all task statuses from Web Api
        public async Task<IEnumerable<TaskStatuses>> GetAllTaskStatusess()
        {
            HttpResponseMessage response = await client.GetAsync("/api/taskstatus/");
            response.EnsureSuccessStatusCode(); // Throw on error code.
            var taskstatus = await response.Content.ReadAsAsync<IEnumerable<TaskStatuses>>();
            return taskstatus;
        }

        //show all tasks from selected task list
        private async void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow td = sender as DataGridRow;
            Tasklist tl = td.Item as Tasklist;
            var task = await GetAllTasks();
            var taskstatus = await GetAllTaskStatusess();
            var SelectTask = from t in task
                             join ts in taskstatus on t.TaskStatusId equals ts.TaskStatusId
                             where t.TaskListId == tl.Id
                             select new { Name = t.Name, Status = ts.Name };
            TaskGrid.ItemsSource = SelectTask;
        }
     
    }
}
