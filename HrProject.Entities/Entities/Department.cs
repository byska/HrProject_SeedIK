using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.Entities.Entities
{
    public class Department : BaseEntity
    {
        public Department()
        {
            AppUsers = new List<AppUser>();
        }
        public string DepartmentName { get; set; }
        //public int CompanyID { get; set; }
        //public virtual Company Company { get; set; }
        public virtual List<AppUser> AppUsers { get; set; }

    }
}
