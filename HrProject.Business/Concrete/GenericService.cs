
using HrProject.Business.Abstract;
using HrProject.DataAccess.UnitOfWork;
using HrProject.Entities.Abstract;
using HrProject.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.Business.Concrete
{
    public class GenericService<T> : IGenericService<T> where T : class , IBaseEntity
    {
        
        private readonly IUow _uow;

        public GenericService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<bool> Activate(int id)
        {
            if (id == 0 || _uow.GetRepository<T>().GetByID(id) == null)
                return false;
            else
                return await _uow.GetRepository<T>().Activate(id);
        }

        public async Task<bool> Add(T entity)
        {
            var result= await _uow.GetRepository<T>().Add(entity);
            await _uow.SaveChangesAsync();
            return result;
        }

        public async Task<bool> Add(List<T> entities)
        {
            return await _uow.GetRepository<T>().AddRangeAsync(entities);
        }

        public async Task<bool> Any(Expression<Func<T, bool>> exp)
        {
            return await _uow.GetRepository<T>().Any(exp);
        }

        public async Task<List<T>> GetActive()
        {
            return await _uow.GetRepository<T>().GetActive();
        }

        public async Task<IQueryable<T>> GetActive(params Expression<Func<T, object>>[] includes)
        {
            return await _uow.GetRepository<T>().GetActivesAsync(includes);
        }

        public async Task<List<T>> GetAll()
        {
            return await _uow.GetRepository<T>().GetAllAsync();
        }

        public async Task<IQueryable<T>> GetAll(params Expression<Func<T, object>>[] includes)
        {
            return await _uow.GetRepository<T>().GetAllAsync(includes);
        }

        public async Task<IQueryable<T>> GetAll(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includes)
        {
            return await _uow.GetRepository<T>().GetAllAsync(exp, includes);
        }

        public async Task<T> GetByDefault(Expression<Func<T, bool>> exp)
        {
            return await _uow.GetRepository<T>().GetByDefault(exp);
        }

        public T GetById(int id)
        {
            return _uow.GetRepository<T>().GetByID(id);
        }

        public IQueryable<T> GetById(int id, params Expression<Func<T, object>>[] includes)
        {
            return _uow.GetRepository<T>().GetByID(id, includes);
        }

        public async Task<IEnumerable<T>> GetDefault(Expression<Func<T, bool>> expression)
        {
            return await _uow.GetRepository<T>().GetDefault(expression);
        }

        public bool Remove(T entity)
        {
            if (entity == null)
                return false;
            else
                return _uow.GetRepository<T>().Remove(entity);
        }

        public bool Remove(int id)
        {
            if (id <= 0) return false;
            else return _uow.GetRepository<T>().Remove(id);
        }

        public bool Update(T entity)
        {
            if (entity == null)
                return false;
            else
            {
                var result = _uow.GetRepository<T>().Update(entity);
                _uow.SaveChangesAsync();
                return result;
            }

              
        }
    }
}
