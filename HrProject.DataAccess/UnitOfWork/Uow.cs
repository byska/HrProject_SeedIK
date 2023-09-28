using HrProject.DataAccess.Abstract;
using HrProject.DataAccess.Concrete;
using HrProject.DataAccess.Context;
using HrProject.Entities.Abstract;
using HrProject.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.DataAccess.UnitOfWork
{
    public class Uow :IUow
    {
        private readonly HrProjectContext _context;

        public Uow(HrProjectContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> GetRepository<T>() where T : class,IBaseEntity
        {
            return new GenericRepository<T>(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
