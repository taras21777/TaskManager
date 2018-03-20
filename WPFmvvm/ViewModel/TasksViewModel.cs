using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFmvvm.Model;

namespace WPFmvvm.ViewModel
{
    public class TasksViewModel : ViewModelBase
    {

        public Tasks Task1;

        public TasksViewModel(Tasks tasks)
        {
            this.Task1 = tasks;
            
        }

        public Tasks GetTask
        {
            get { return Task1; }
        }

        public string Name
        {
            get { return Task1.Name; }
            set
            {
                Task1.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Id
        {
            get { return Task1.TaskId; }
            set
            {
                Task1.TaskId = value;
                OnPropertyChanged("Id");
            }
        }

        public int TaskStatusId
        {
            get { return Task1.TaskStatusId; }
            set
            {
                Task1.TaskStatusId = value;
                OnPropertyChanged("Id");
            }
        }

        private Tasks selectedTask;
        public Tasks SelectedTask
        {
            get { return selectedTask; }
            set
            {
                selectedTask = value;
                OnPropertyChanged("SelectedTask");
            }
        }


        public int TaskListId
        {
            get { return Task1.TaskListId; }
            set
            {
                Task1.TaskListId = value;
                OnPropertyChanged("Id");
            }
        }
    }
}
