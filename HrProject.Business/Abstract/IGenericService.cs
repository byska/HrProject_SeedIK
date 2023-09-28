using HrProject.Entities.Abstract;
using HrProject.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.Business.Abstract
{
    public interface IGenericService<T> where T : class , IBaseEntity
    {
        Task<bool> Activate(int id);
        Task<bool> Add(T entity);
        Task<bool> Add(List<T> entities);
        Task<bool> Any(Expression<Func<T, bool>> exp);
        Task<List<T>> GetActive();
        Task<IQueryable<T>> GetActive(params Expression<Func<T, object>>[] includes);
        Task<List<T>> GetAll();
        Task<IQueryable<T>> GetAll(params Expression<Func<T, object>>[] includes);
        Task<IQueryable<T>> GetAll(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includes);
        Task<T> GetByDefault(Expression<Func<T, bool>> exp);
        T GetById(int id);
        IQueryable<T> GetById(int id, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetDefault(Expression<Func<T, bool>> expression);
        bool Remove(T entity);
        bool Remove(int id);
        bool Update(T entity);
    }
}
