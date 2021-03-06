﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ReimbursementApp.Data.Contracts;

namespace ReimbursementApp.EFRepository
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        public EFRepository(Microsoft.EntityFrameworkCore.DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext");
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        protected Microsoft.EntityFrameworkCore.DbContext DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }

        /*TODO: Paging support, if needs to be done from server side*/
        /* public IQueryable<T> GetAll(Pager queryObj)
         {
             IQueryable<T> query = DbSet;

             if (queryObj.Page <= 0)
                 queryObj.Page = 1;

             if (queryObj.PageSize <= 0)
                 queryObj.PageSize = 10;
             query = query.Skip((queryObj.Page - 1) * queryObj.PageSize).Take(queryObj.PageSize);

             return query;
         }*/

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public virtual T GetById(int id)
        {
            return DbSet.Find(id);
        }


        public virtual void Add(T entity)
        {
            EntityEntry<T> dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != (EntityState)EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public virtual void Update(T entity)
        {
            EntityEntry<T> dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != (EntityState)EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            EntityEntry<T> dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != (EntityState)EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return;

            Delete(entity);
        }

        /*  public virtual object Include<TEntity, TProperty>(Func<TEntity, TProperty> p) where TEntity : class
          {
              return DbSet;
          }*/
    }
}
