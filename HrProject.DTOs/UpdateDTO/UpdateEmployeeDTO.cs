using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrProject.DTOs.UpdateDTO
{
    public class UpdateEmployeeDTO
    {
        public int? Id { get; set; }
        public string EmployeeImage { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
