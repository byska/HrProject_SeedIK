
using HrProject.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HrProject.DTOs
{
    public class UserSignInDTO
    {
        public int ID { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public Gender Gender { get; set; }
        public int WorkingYear { get; set; }
    }
}
