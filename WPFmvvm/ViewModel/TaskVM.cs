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
    public class TaskVM : ViewModelBase
    {
        
        public TaskVM()
        {
            Start();
        }


        public async void Start()
        {
            TaskList t = new TaskList();
            var reports = await t.GetAll();
            ObservableCollection<TaskList> Tasklists = new ObservableCollection<TaskList>(reports);
            Tasklist = new ObservableCollection<TaskListViewModel>(Tasklists.Select(taskl => new TaskListViewModel(taskl)));

            Tasks t1 = new Tasks();
            var reports1 = await t1.GetAll();
            ObservableCollection<Tasks> tasks = new ObservableCollection<Tasks>(reports1);
            task1 = new ObservableCollection<TasksViewModel>(tasks.Select(tasks1 => new TasksViewModel(tasks1)));
        }


        public ObservableCollection<TasksViewModel> Task1;

        public ObservableCollection<TasksViewModel> task1
        {
            get
            { 
                return Task1;
            }
            set
            {
                Task1 = value;
                OnPropertyChanged("task1");
            }
        }



        public ObservableCollection<TaskListViewModel> Tasklist1;

        public ObservableCollection<TaskListViewModel> Tasklist
        {
            get { return Tasklist1; }
            set
            {
                Tasklist1 = value;
                OnPropertyChanged("Tasklist");
            }
        }

    }
}

