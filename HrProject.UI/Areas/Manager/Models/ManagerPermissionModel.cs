using HrProject.Enums;
using HrProject.UI.Areas.Employee.Models;
using X.PagedList;

namespace HrProject.UI.Areas.Manager.Models
{
    public class ManagerPermissionModel
    {
        public int ID { get; set; }
        public PermissionType Type { get; set; }
        public int TypeID { get; set; }
        public int AppUserID { get; set; }
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
        public IFormFile SelectFile { get; set; }
        public string? File { get; set; }
        //public IPagedList<PermissionVM>? Permissions { get; set; }
        public string? EmployeeName { get; set; }
    }
}
