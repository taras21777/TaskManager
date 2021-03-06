﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFmvvm.Model
{
    public abstract class HttpRepository<T> : ICRUD<T>
    {
        public abstract Task<IEnumerable<T>> GetAll();
        public abstract void AddNew(T t);
        public abstract void DeleteSelected(T t);
    }
}
