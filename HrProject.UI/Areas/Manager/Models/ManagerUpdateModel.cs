using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HrProject.UI.Areas.Manager.Models
{
    public class ManagerUpdateModel
    {
        public int ID { get; set; }
        public string ManagerImage { get; set; }

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
