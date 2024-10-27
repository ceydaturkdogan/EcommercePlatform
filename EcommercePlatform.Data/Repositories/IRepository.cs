﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePlatform.Data.Repositories
{
    public interface IRepository<TEntity> 
        where TEntity : class
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);

        void Delete(int id);

        void Update(TEntity entity);

        TEntity GetById(int id);

        TEntity Get(Expression<Func<TEntity,bool>> predicate);



    }
}
