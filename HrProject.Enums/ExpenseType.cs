using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HrProject.Enums
{
    public enum ExpenseType
    {
        [Display(Name = "Konaklama")]
        Accommodation,
        [Display(Name = "Seyahat")]
        Trip,
        [Display(Name = "Yeme ve İçme")]
        FoodAndBeverage
    }
}
