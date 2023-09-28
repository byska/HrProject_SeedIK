using Microsoft.AspNetCore.Mvc.Rendering;

namespace HrProject.UI.Areas.Employee.Models
{
    public class PermissionVM
    {
        public PermissionVM()
        {
            PermissionTypeDropDown = new List<SelectListItem>();
            Permissions = new List<PermissionModel>();
            Permission=new PermissionModel();
        }
        public List<SelectListItem> PermissionTypeDropDown { get; set; }
        public List<PermissionModel> Permissions { get; set; }
        public PermissionModel Permission { get; set; } 
    }
}
