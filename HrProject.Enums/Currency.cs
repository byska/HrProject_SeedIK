using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HrProject.Enums
{
    public enum Currency
    {
        [Display(Name = "TL")]
        TurkLirasi,
        [Display(Name = "Dolar")]
        Dolar,
        [Display(Name = "Euro")]
        Euro
    }
}
