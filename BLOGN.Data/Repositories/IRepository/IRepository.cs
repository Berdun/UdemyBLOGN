using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLOGN.Data.Repositories.IRepository
{
     public interface IRepository<T> where T : class
     {
          Task<ICollection<T>> GetAll(Expression<Func<T,bool>> filter = null,
               Func<IQueryable<T>,IOrderedQueryable<T>> orderBy=null, string includeProperties=null);
          Task<T> Get(int id);
          Task<T> GetFirstOrDefault(Expression<Func<T,bool>> filter = null,
               string includeProperties = null);
          Task<bool> Add(T entity);
          T Update(T entity);
          bool Delete(int id);
     }
}
