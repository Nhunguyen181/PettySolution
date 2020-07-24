using Microsoft.EntityFrameworkCore;
using PettySolution.Application.Catalog.Interfaces;
using PettySolution.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PettySolution.Application.Catalog.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        protected readonly projectContext context;
        protected readonly DbSet<T> dbSet;

        public ServiceBase(projectContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Add(IEnumerable<T> list)
        {
            dbSet.AddRange(list);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            dbSet.RemoveRange(dbSet.Where(where));
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public T GetById(string id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
        }
    }

}
