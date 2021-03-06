﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFmvvm.Model;

namespace WPFmvvm.ViewModel
{
    public class TaskListViewModel : ViewModelBase
    {
        public TaskList Tasklist;

        public TaskListViewModel(TaskList tasklist)
        {
            this.Tasklist = tasklist;
            
        }
        public TaskList GetTaskList
        {
            get { return Tasklist; }
        }

        public ObservableCollection<Tasks> TaskListID
        {
            get { return Tasklist.TaskListID; }
            set {
                Tasklist.TaskListID = value;
                OnPropertyChanged("TaskListAdd");
            }
        }

        public DateTime CreateDate
        {
            get { return Tasklist.CreateDate; }
            set
            {
                Tasklist.CreateDate = value;
                OnPropertyChanged("CreateDate");
            }
        }
        public DateTime DueDate
        {
            get { return Tasklist.DueDate; }
            set
            {
                Tasklist.DueDate = value;
                OnPropertyChanged("DueDate");
            }
        }

        public string Name
        {
            get { return Tasklist.Name; }
            set
            {
                Tasklist.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Id
        {
            get { return Tasklist.Id; }
            set
            {
                Tasklist.Id = value;
                OnPropertyChanged("Id");
            }
        }

       



    }
}
