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
            phonesGrid.ItemsSource = reports;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("/api/tasklists/" + txtId.Text);
                response.EnsureSuccessStatusCode(); // Throw on error code.
                MessageBox.Show("Tasklist Successfully Deleted");
                phonesGrid.ItemsSource = await GetAllTasklists();
                phonesGrid.ScrollIntoView(phonesGrid.ItemContainerGenerator.Items[phonesGrid.Items.Count - 1]);
            }
            catch (Exception)
            {
                MessageBox.Show("Tasklist Deletion Unsuccessful");
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
            var task = await GetAllTasks();
            var taskstatus = await GetAllTaskStatusess();
            var SelectTask = from t in task
                             join ts in taskstatus on t.TaskStatusId equals ts.TaskStatusId
                             where t.TaskListId == tl.Id
                             select new { Name = t.Name, Status = ts.Name };
            TaskGrid.ItemsSource = SelectTask;

            //DataGridTextColumn c1 = new DataGridTextColumn();
            //c1.Header = "Name";
            //c1.Binding = new Binding("Name");
            //c1.Width = 110;
            //TaskGrid.Columns.Add(c1);
            //DataGridTextColumn c2 = new DataGridTextColumn();
            //c2.Header = "Status";
            //c2.Width = 110;
            //c2.Binding = new Binding("Status");
            //TaskGrid.Columns.Add(c2);

            //TaskGrid.Items.Add();
            //TaskGrid.Items.Add(new Item() { Num = 2, Start = "2012, 12, 15" });
            //TaskGrid.Items.Add(new Item() { Num = 3, Start = "2012, 8, 1" });

        }
     
    }
}
