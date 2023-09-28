using HrProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.Entities.Entities
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
