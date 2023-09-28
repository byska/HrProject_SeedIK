using HrProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.DTOs.DTOs
{
    public class ChangeStatusDTO
    {
        public int itemId { get; set; }
        public string newStatus { get; set; }
    }
}
