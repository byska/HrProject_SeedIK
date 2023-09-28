namespace HrProject.UI.Areas.Manager.Models
{
    public class EmployeeVM
    {
        public EmployeeVM()
        {
            Employees = new List<ManagerListEmployeeDTO>();
        }
        public ManagerListEmployeeDTO Employee { get; set; }
        public List<ManagerListEmployeeDTO> Employees { get; set; }
    }
}
