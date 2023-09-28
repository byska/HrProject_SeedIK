using System.ComponentModel.DataAnnotations;

namespace HrProject.UI.Areas.Manager.Models
{
    public class ManagerModel
    {
        public int ID { get; set; }
        public bool IsActive { get; set; }
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
        public int JobID { get; set; }
        public int DepartmentID { get; set; }
        public int CompanyID { get; set; }
        public string Email { get { return $"{FirstName.ToUpper()}.{LastName.ToUpper()}@bilgeadamboost.com"; } }
        public string Address { get; set; }

        [StringLength(14)]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:#-###-###-####}", ApplyFormatInEditMode = true)]
        public string PhoneNumber { get; set; }
    }
}
