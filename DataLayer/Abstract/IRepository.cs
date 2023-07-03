﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Abstract
{
    public interface IRepository<T>
    {
        void Insert (T entity);
        void Update (T entity);
        void Delete (T entity);
        List<T> List();
        List<T> List(Expression<Func<T, bool>> filter);
        T Get(Expression<Func<T, bool>> filter);
    }
}
