using HrProject.Entities.Abstract;
using HrProject.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.Entities.Entities
{
    public class AppUser : IdentityUser<int> , IBaseEntity
    {
        //public string ManagerImage { get; set; } = "/images/9d5fc47e-8afe-40bd-bb03-edd1d2460c5a_pngwing.com(3).png";
        public string EmployeeImage { get; set; } = "/images/9d5fc47e-8afe-40bd-bb03-edd1d2460c5a_pngwing.com(3).png";
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
        public virtual Job Job { get; set; } //Profession
        //Department
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; } 
        //Company
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }
        public override string Email { get { return $"{FirstName.ToLower()}.{LastName.ToLower()}@bilgeadamboost.com"; } }
        public string Address { get; set; }
        public int Salary { get; set; }
        public bool IsActive { get; set; }
        public Gender Gender { get; set; }
       public List<Permission> Permissions { get; set; }
        public List<AdvancePayment> AdvancePayments { get; set; }
        public List<Expense> Expenses { get; set; }
        public AppUser()
        {
            AdvancePayments = new List<AdvancePayment>();
            Expenses = new List<Expense>();
            Permissions = new List<Permission>();
        }
    }
}
