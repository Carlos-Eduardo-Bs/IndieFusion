using System.ComponentModel.DataAnnotations;

namespace IndieFusionAPI.Models
{
    public class UserLogin
    {
        [StringLength(150)]
        [Required(ErrorMessage = "Enter nickname !")]
        [Display(Name = "NickName")]
        public string NickName { get; set; }

        [StringLength(6)]
        [Required(ErrorMessage = "Enter password !")]
        [Display(Name = "Password")]
        public string PasswordUser { get; set; }
    }
}
