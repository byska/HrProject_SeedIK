using Microsoft.AspNetCore.Mvc.Rendering;

namespace HrProject.UI.Areas.Manager.Models
{
    public class PermissionVM
    {
        public PermissionVM()
        {
            PermissionTypeDropDown = new List<SelectListItem>();
            Permissions = new List<PermissionModel>();
        }
        public List<SelectListItem> PermissionTypeDropDown { get; set; }
        public List<PermissionModel> Permissions { get; set; }
        public PermissionModel Permission { get; set; } 
    }
}
