using BLOGN.Data.Repositories.IRepository;
using BLOGN.SharedTools;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLOGN.Data.Repositories.Repository
{
     public class Repository<T> : IRepository<T> where T : class
     {
          private readonly ApplicationDbContext _context;
          internal DbSet<T> _dbSet;

          public Repository(ApplicationDbContext context)
          {
               _context = context;
               _dbSet = _context.Set<T>();
          }

          public async Task<bool> Add(T entity)
          {
               await _dbSet.AddAsync(entity);
               return true;
          }

          public bool Delete(int id)
          {
               T entity = _dbSet.Find(id);
                _dbSet.Remove(entity);
               return true;
          }

          public async Task<T> Get(int id)
          {
               return await _dbSet.FindAsync(id);
          }

          public async Task<ICollection<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
          {
               IQueryable<T> query = _dbSet;

               if (filter != null)
               {
                    query = query.Where(filter);
               }

               if (includeProperties != null)
               {
                    foreach (var iProperty in includeProperties.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
                    {
                         query = query.Include(iProperty);
                    }
               }

               if (orderBy != null)
               {
                    return await orderBy(query).ToListAsync();
               }
               return await query.ToListAsync();

          }

          public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
          {
               IQueryable<T> query = _dbSet;

               if (filter != null)
               {
                    query = query.Where(filter);
               }

               if (includeProperties != null)
               {
                    foreach (var iProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                         query = query.Include(iProperty);
                    }
               }

               
               return await query.FirstOrDefaultAsync();
          }

          public T Update(T entity)
          {
               _context.Update(entity);
               return entity;
          }
     }
}
