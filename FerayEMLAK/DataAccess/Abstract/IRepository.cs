﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public string Insert(TEntity entity);
        public string Update(TEntity entity);
        public string Delete(Expression<Func<TEntity, bool>> where);

        public IList<TEntity> GetAll();
        public TEntity GetById(Expression<Func<TEntity, bool>> where);
    }
}
