using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PettySolution.Application.Catalog.Interfaces
{
    public interface IServiceBase<T> where T : class
    {
        void Add(T entity);
        void Add(IEnumerable<T> list);
        T Get(Expression<Func<T, bool>> where);
        IQueryable<T> GetAll();
        T GetById(string id);
        IQueryable<T> GetMany(Expression<Func<T, bool>> where);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        void SaveChanges();
    }
}
