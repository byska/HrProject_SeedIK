using HrProject.Entities.Abstract;
using HrProject.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.DataAccess.Abstract
{
    public interface IGenericRepository<T> where T :class, IBaseEntity
    {
        Task<bool> Activate(int id);
        Task<bool> Add(T entity);
        Task<bool> AddRangeAsync(List<T> entities);
        Task<bool> Any(Expression<Func<T, bool>> exp);
        Task<List<T>> GetActive();
        Task<IQueryable<T>> GetActivesAsync(params Expression<Func<T, object>>[] includes);
        Task<List<T>> GetAllAsync();
        Task<IQueryable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includes);
        Task<T> GetByDefault(Expression<Func<T, bool>> exp);
        T GetByID(int id);
        IQueryable<T> GetByID(int id, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetDefault(Expression<Func<T, bool>> exp);
        bool Remove(T entity);
        bool Remove(int id);
        bool Update(T entity);
    }
}
