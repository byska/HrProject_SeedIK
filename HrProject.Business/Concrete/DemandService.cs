using HrProject.Business.Abstract;
using HrProject.DataAccess.UnitOfWork;
using HrProject.DTOs.CreateDTO;
using HrProject.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.Business.Concrete
{
    public class DemandService : GenericService<Permission>,IDemandService
    {
        private readonly IUow _uow;
        public async Task<bool> AddPermission(Permission entity)
        {
            if(entity.File == null)
            {
                return false;
            }
            var result = await _uow.GetRepository<Permission>().Add(entity);
            await _uow.SaveChangesAsync();
            return result;
        }
        public DemandService(IUow uow) : base(uow)
        {
            _uow = uow;
        }
    }
}
