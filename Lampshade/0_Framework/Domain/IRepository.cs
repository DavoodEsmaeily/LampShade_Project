using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace _0_Framework.Domain
{
  public interface IRepository<TKey , T> where T : class
    {
        void Create(T entity);
        T Get(TKey id);
        List<T> Get();
        bool Exsists(Expression<Func<T, bool>> expression);
        void SaveChanges();
    }
}
