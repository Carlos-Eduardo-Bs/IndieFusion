using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IndieFusionFinal.Models
{
    [Table("UserType")]
    public class UserType
    {
        [Key]
        public int Id { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "Enter UserType !")]
        [Display(Name = "Description UserType")]
        public string Description { get; set; }
    }
}
