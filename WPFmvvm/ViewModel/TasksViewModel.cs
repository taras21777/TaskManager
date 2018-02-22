using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
