﻿using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryDbContext RepositoryContext { get; set; }

        public RepositoryBase(RepositoryDbContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression);
        }

        public virtual void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
        }

        public virtual void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }

    }
}
