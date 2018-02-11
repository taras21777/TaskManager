using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
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
using WPFmvvm.Model;

namespace WPFmvvm.ViewModel
{
    public class TaskVM : INotifyPropertyChanged
    {
        HttpClient client = new HttpClient();
        public TaskVM()
        {
            client.BaseAddress = new Uri("http://localhost:41447/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
          
            var TaskLists = GetAllTasklists();
            //???????????????????????????????????????????????????????????????????????????????????
           
        }

        public async Task<IEnumerable<TaskList>> GetAllTasklists()
        {
            HttpResponseMessage response = await client.GetAsync("/api/tasklists");
            response.EnsureSuccessStatusCode(); // Throw on error code.
            var tasklist = await response.Content.ReadAsAsync<IEnumerable<TaskList>>();
            return tasklist;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
