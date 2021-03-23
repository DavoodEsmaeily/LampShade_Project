using _0_Framework.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace _0_Framework.InfraStructure
{
   public class RepositoryBase<TKey, T> : IRepository<TKey, T> where T : class
    {
        private readonly DbContext context;

        public RepositoryBase(DbContext context)
        {
            this.context = context;
        }

        public void Create(T entity)
        {
            context.Add<T>(entity);
        }

        public bool Exsists(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Any(expression);
        }

        public T Get(TKey id)
        {
            return context.Find<T>(id);
            //return context.Set<T>().Find(id);
        }

        public List<T> Get()
        {
            return context.Set<T>().ToList();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
