
using Microsoft.Build.Framework;
using Newtonsoft.Json.Serialization;

namespace HrProject.UI.Models
{
    public class UserSignInModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
