using HrProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.DTOs.DTOs
{
    public class PermissionTypeDTO
    {
        public int ID { get; set; }
        public string PermissionName { get; set; }
        public double PermissionDay { get; set; }
        public bool IsFileRequired { get; set; }=false;
        public Gender Gender { get; set; } = Gender.All;
    }
}
