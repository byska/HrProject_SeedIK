using HrProject.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.Business.Abstract
{
    public interface IDemandService:IGenericService<Permission>
    {
         Task<bool> AddPermission(Permission entity);
    }
}
