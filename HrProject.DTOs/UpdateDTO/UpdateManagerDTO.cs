using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.DTOs.UpdateDTO
{
    public class UpdateManagerDTO
    {
        public int? Id { get; set; }
        public string ManagerImage { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
