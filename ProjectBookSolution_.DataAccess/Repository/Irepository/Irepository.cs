using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBookSolution_.DataAccess.Repository.Irepository
{
   public interface Irepository<T> where T:class
    {
        void Add(T entity);
        void Remove(T entity);
        void Remove(int id);
        void RemoveRange(IEnumerable<T> entity);
        T Get(int id);
        IEnumerable<T> GetAll(
            Expression<Func<T,bool>>Filter=null,
            Func<IQueryable<T>,IOrderedQueryable<T>>OrderBy=null,
            string includeProperties = null
            );
        T FirstORDefault(
            Expression<Func<T, bool>> Filter = null, bool tracked = true,
             string includeProperties = null
            );

    }
}
