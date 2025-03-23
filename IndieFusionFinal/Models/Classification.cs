using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IndieFusionFinal.Models
{
    [Table("Classification")]
    public class Classification
    {
        public int Id { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "Enter Classification !")]
        [Display(Name = "Description Classification")]
        public string Description { get; set; }
    }
}
