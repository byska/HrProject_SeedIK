using HrProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.UI.Areas.Manager.Models
{
    public class ManagerListEmployeeDTO
    {
        public int Id { get; set; }
        public string EmployeeImage { get; set; }
        public string FirstName { get; set; }
        public string? SecondFirstName { get; set; }
        public string LastName { get; set; }
        public string? SecondLastName { get; set; }
        public string Email { get { return $"{FirstName.ToLower()}.{LastName.ToLower()}@bilgeadamboost.com"; } }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int JobID { get; set; }
        public int DepartmentID { get; set; }
        public int CompanyID { get; set; }
        public Gender Gender { get; set; }
        public JobDTO Job { get; set; }
        public DepartmentDTO Department { get; set; }
        public CompanyDTO Company { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? DismissalDate { get; set; }

    }
}
