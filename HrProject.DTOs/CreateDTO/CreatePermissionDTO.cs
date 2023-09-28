using HrProject.DTOs.DTOs;
using HrProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HrProject.DTOs.CreateDTO
{
    public class CreatePermissionDTO
    {
        public int ID { get; set; }
        public int TypeId { get; set; }
        public int AppUserID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfDays
        {
            get
            {
                TimeSpan extraction = EndDate - StartDate; return extraction.Days;
            }
        }
        public Status Status { get; set; }
        public string? File { get; set; }
    }
}
