using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HrProject.Enums
{
    public enum Gender
    {
        [Display(Name = "Kadın")]
        Female,
        [Display(Name = "Erkek")]
        Male,
        All
    }
}
