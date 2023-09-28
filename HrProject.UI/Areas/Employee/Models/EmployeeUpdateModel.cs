using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrProject.UI.Areas.Employee.Models
{
    public class EmployeeUpdateModel
    {
        public int ID { get; set; }
        public string EmployeeImage { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [Display(Name = "Image")]
        [DataType(DataType.Upload)]
        public IFormFile ImageFile { get; set; }
        public string Address { get; set; }
        [StringLength(14)]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:#-###-###-####}", ApplyFormatInEditMode = true)]
        public string PhoneNumber { get; set; }
    }
}
