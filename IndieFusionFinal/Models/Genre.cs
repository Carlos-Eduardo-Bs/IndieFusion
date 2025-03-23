using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IndieFusionFinal.Models
{
    [Table("Genre")]
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "Enter Genre !")]
        [Display(Name = "Description Genre")]
        public string Description { get; set; }

        [StringLength(250)]
        [Display(Name = "Genre Image")]
        public string? ImagePath { get; set; }
    }
}