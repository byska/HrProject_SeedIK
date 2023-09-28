using HrProject.Enums;

namespace HrProject.UI.Areas.Admin.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string EmployeeImage { get; set; }
        public string FirstName { get; set; }
        public string? SecondFirstName { get; set; }
        public string LastName { get; set; }
        public string? SecondLastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string TC { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? DismissalDate { get; set; }
        //Job
        public int JobID { get; set; }
        //Department
        public int DepartmentID { get; set; }
        //Company
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }
        public string Email { get { return $"{FirstName.ToLower()}.{LastName.ToLower()}@bilgeadamboost.com"; } }
        public string Address { get; set; }
        public int Salary { get; set; }
        public bool IsActive { get; set; }
        public Gender Gender { get; set; }
    }
}
