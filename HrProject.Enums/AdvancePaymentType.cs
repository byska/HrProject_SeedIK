using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.Enums
{
    public enum AdvancePaymentType
    {
        [Display(Name ="Bireysel")]
        Personal,
        [Display(Name = "Kurumsal")]
        Corporative 
    }
}
