using HrProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.Entities.Entities
{
    public class PermissionType : BaseEntity
    {
        public PermissionType()
        {
            Permissions = new List<Permission>();
        }
        public string PermissionName { get; set; }
        public int PermissionDay { get; set; }
        public bool IsFileRequired { get; set; }=false;
        public Gender Gender { get; set; } = Gender.All;
        public virtual List<Permission> Permissions { get; set; }
    }
}
