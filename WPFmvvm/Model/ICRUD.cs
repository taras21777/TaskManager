using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFmvvm.Model
{
    interface ICRUD<T>
    {
        Task<IEnumerable<T>> GetAll();
        void AddNew(T t);
        void DeleteSelected(T t);
    }
}
