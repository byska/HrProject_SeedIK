using HrProject.DataAccess.Abstract;
using HrProject.DataAccess.Context;
using HrProject.Entities.Abstract;
using HrProject.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HrProject.DataAccess.Concrete
{
    public class GenericRepository<T> :IGenericRepository<T> where T : class, IBaseEntity
    {
        private readonly HrProjectContext context;
        public GenericRepository(HrProjectContext _context)
        {
            context = _context;
        }
        public async Task<bool> Activate(int id)
        {
            T item = GetByID(id);
            item.IsActive = true;
            return Update(item);
        }

        public async Task<bool> Add(T entity)
        {
            try
            {
                await context.Set<T>().AddAsync(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> AddRangeAsync(List<T> entities)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (T entity in entities)
                    {
                        context.Set<T>().AddAsync(entity);
                    }
                    ts.Complete();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Any(Expression<Func<T, bool>> exp) => await context.Set<T>().AnyAsync(exp);

        public async Task<List<T>> GetActive() => await context.Set<T>().Where(x => x.IsActive == true).ToListAsync();

        public async Task<IQueryable<T>> GetActivesAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = context.Set<T>().Where(x => x.IsActive == true);
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }

        public async Task<List<T>> GetAllAsync() => await context.Set<T>().ToListAsync();

        public async Task<IQueryable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = context.Set<T>().AsQueryable();
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }

        public  async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includes)
        {
            var query = context.Set<T>().Where(exp);
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }

        public async Task<T> GetByDefault(Expression<Func<T, bool>> exp) => await context.Set<T>().FirstOrDefaultAsync(exp);

        public T GetByID(int id) => context.Set<T>().Find(id);

        public IQueryable<T> GetByID(int id, params Expression<Func<T, object>>[] includes)
        {
            var query = context.Set<T>().Where(x => x.Id == id);
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }

        public async Task<IEnumerable<T>> GetDefault(Expression<Func<T, bool>> exp) => await context.Set<T>().Where(exp).ToListAsync();
        
        public bool Remove(T entity)
        {
            entity.IsActive = false;
            return Update(entity);
        }

        public bool Remove(int id)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    T item =GetByID(id);
                    item.IsActive = false;
                    ts.Complete();
                    return Update(item);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                context.Set<T>().Update(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
