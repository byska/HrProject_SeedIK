using HrProject.Enums;

namespace HrProject.UI.Areas.Employee.Models
{
    public class PermissionType
    {
        public int ID { get; set; }
        public string PermissionName { get; set; }
        public double PermissionDay { get; set; }
        public bool IsFileRequired { get; set; }=false;
        public Gender Gender { get; set; } = Gender.All;
    }
}
