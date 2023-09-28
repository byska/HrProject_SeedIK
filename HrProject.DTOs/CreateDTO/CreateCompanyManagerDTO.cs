using HrProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.DTOs.CreateDTO
{
    public class CreateCompanyManagerDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string EmployeeImage { get; set; }
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
        public bool IsActive { get; set; }
        public Gender Gender { get; set; }
    }
}
