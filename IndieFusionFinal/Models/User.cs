using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IndieFusionFinal.Models
{

    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "Enter Name !")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "Enter NickName !")]
        [Display(Name = "NickName")]
        public string NickName { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "Enter Email !")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(6)]
        [Required(ErrorMessage = "Enter Password !")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Enter Birth Date!")]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [StringLength(250)]
        [Display(Name = "Image")]
        public string? ImagePath { get; set; }

        [ForeignKey("UserType")]
        [Required(ErrorMessage = "Select a UserType !")]
        [Display(Name = "UserType")]
        public int UserTp { get; set; }
        public virtual UserType? UserType { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}

