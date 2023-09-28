using HrProject.Enums;

namespace HrProject.UI.Areas.Admin.Models
{
    public class CompanyManagerModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? EmployeeImage { get; set; } = "/images/9d5fc47e-8afe-40bd-bb03-edd1d2460c5a_pngwing.com(3).png";
        public string FirstName { get; set; }
        public string? SecondFirstName { get; set; }
        public string LastName { get; set; }
        public string? SecondLastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string TC { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        //Job
        public int JobID { get; set; }
        //Department
        public int DepartmentID { get; set; }
        //Company
        public int CompanyID { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
        public bool IsActive { get; set; }=true;
        public Gender Gender { get; set; } = Gender.Male;
    }
}
