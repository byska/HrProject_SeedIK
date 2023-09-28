
using HrProject.Entities.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.Entities.Entities
{
    public class AppRole : IdentityRole<int>, IBaseEntity
    {
        public bool IsActive { get; set; }
    }
}
