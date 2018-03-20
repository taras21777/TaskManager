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
            //get all tasks and set into Task1 (observablecollection)
            Tasks t1 = new Tasks();
            var reports1 = await t1.GetAll();
            ObservableCollection<Tasks> tasks = new ObservableCollection<Tasks>(reports1);
            task1 = new ObservableCollection<TasksViewModel>(tasks.Select(tasks1 => new TasksViewModel(tasks1)));
           
            //get all tasks and set into Tasklist1 (observablecollection)
            TaskList t = new TaskList();
            var reports = await t.GetAll();
            ObservableCollection<TaskList> Tasklists = new ObservableCollection<TaskList>(reports);
            Tasklist = new ObservableCollection<TaskListViewModel>(Tasklists.Select(taskl =>
            {
                var lt = from t2 in task1
                         where t2.TaskListId == taskl.Id
                         select t2.Task1;
                ObservableCollection<Tasks> lt1 = new ObservableCollection<Tasks>(lt);
                taskl.TaskListID = lt1;
                return new TaskListViewModel(taskl);
            }
            ));            
        }

        TaskListViewModel selectedTaskListViewModel;
        public TaskListViewModel SelectedTaskListViewModel
        {
            get { return selectedTaskListViewModel; }
            set
            {
                selectedTaskListViewModel = value;
                OnPropertyChanged("SelectedTaskListViewModel");
            }
        }

        Tasks selectedTask;
        public Tasks SelectedTask
        {
            get { return selectedTask; }
            set
            {
                selectedTask = value;
                OnPropertyChanged("SelecteTask");
            }
        }


        private RelayCommand deleteTaskListCommand;
        public RelayCommand DeleteTaskListCommand
        {
            get
            {
                return deleteTaskListCommand ??
                    (deleteTaskListCommand = new RelayCommand(obj  =>
                    {
                        if(SelectedTaskListViewModel != null)
                        {
                            SelectedTaskListViewModel.Tasklist.DeleteSelected(selectedTaskListViewModel.GetTaskList);
                            task1.Clear();
                            Tasklist.Clear();
                            Start();
                        }                
                    }
                    ));
            }
        }

        private RelayCommand deleteTaskCommand;
        public RelayCommand DeleteTaskCommand
        {
            get
            {
                return deleteTaskCommand ??
                    (deleteTaskCommand = new RelayCommand(obj =>
                    {
                        if (SelectedTask != null)
                        {
                            SelectedTask.DeleteSelected(SelectedTask);
                        }
                    }
                    ));
            }
        }


        //add New Task
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        if(SelectedTaskListViewModel != null)
                        {
                            Tasks t = new Tasks(NewTaskName, 1, SelectedTaskListViewModel.Id);
                            t.AddNew(t);
                            task1.Clear();
                            Tasklist.Clear();
                            Start();                   
                        }                      
                    }));
            }
        }

        private RelayCommand addTaskListCommand;
        public  RelayCommand  AddTaskListCommand
        {
            get
            {
                return addTaskListCommand ??
                    (addTaskListCommand = new RelayCommand(obj =>
                    {
                        
                        TaskList tl = new TaskList(NewTaskListName, DateTime.Now, NewDueDate);
                        tl.AddNew(tl);
                        RefreshData();


                    }));
            }
        }

        public void RefreshData()
        {
            task1.Clear();
            Tasklist.Clear();
            Start();
        }

        private DateTime newDueDate;
        public DateTime NewDueDate
        {
            get { return this.newDueDate; }
            set
            {
                this.newDueDate = value;
                this.OnPropertyChanged();
            }
        }

        private string newTaskListName;
        public string NewTaskListName
        {
            get { return this.newTaskListName; }
            set
            {
                if (!string.Equals(this.newTaskListName, value))
                {
                    this.newTaskListName = value;
                    this.OnPropertyChanged();
                }
            }
        }

        private string newTaskName;
        public string NewTaskName
        {
            get { return this.newTaskName; }
            set
            {
                if (!string.Equals(this.newTaskName, value))
                {
                    this.newTaskName = value;
                    this.OnPropertyChanged(); 
                }
            }
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

