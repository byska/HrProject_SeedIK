using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HrProject.Enums
{
    public enum Status
    {
        [Display(Name = "Onaylandı")]
        Confirm,
        [Display(Name = "Beklemede")]
        Pending,
        [Display(Name = "Reddedildi")]
        Denied
    }
}
