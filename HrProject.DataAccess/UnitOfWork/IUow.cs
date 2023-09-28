using HrProject.DataAccess.Abstract;
using HrProject.Entities.Abstract;
using HrProject.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.DataAccess.UnitOfWork
{
    public interface IUow
    {
        IGenericRepository<T> GetRepository<T>() where T : class, IBaseEntity;
        Task<int> SaveChangesAsync();
    }
}
