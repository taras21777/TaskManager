using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFmvvm.Model
{
    public class TaskList : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private DateTime createdate;
        private DateTime duedate;
      
        public DateTime CreateDate
        {
            get { return createdate; }
            set
            {
                createdate =value;
                OnPropertyChanged("CreateDate");
            }
        }
        public DateTime DueDate
        {
            get { return duedate; }
            set
            {
                duedate = value;
                OnPropertyChanged("DueDate");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
