using HrProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.DTOs.DTOs
{
    public class PermissionDTO
    {
        public int ID { get; set; }
        public int AppUserID { get; set; }
        public int TypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public int NumberOfDays
        {
            get
            {
                TimeSpan extraction = EndDate - StartDate; return extraction.Days;
            }
        }
        public Status Status { get; set; } = Status.Pending;
        public DateTime? ReplyDate { get; set; }
        public string? File { get; set; }
    }
}
