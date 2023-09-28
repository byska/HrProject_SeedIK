using HrProject.Enums;
using Microsoft.Extensions.Hosting;
using X.PagedList;

namespace HrProject.UI.Areas.Manager.Models
{
    public class PermissionModel
    {
        public int ID { get; set; }
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
        public IPagedList<PermissionVM>? Permissions { get; set; }
    }
}
