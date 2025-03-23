using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IndieFusionFinal.Models
{
    [Table("Game")]
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "Enter title !")]
        [Display(Name = "Game Title")]
        public string Title { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "Enter Producer !")]
        [Display(Name = "Game Producer")]
        public string Producer { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Enter price !")]
        [Display(Name = "Game price")]
        public string price { get; set; }

        [StringLength(255)]
        [Display(Name = "Game Image URL")]
        public string? Url { get; set; }

        [StringLength(250)]
        [Display(Name = "Game Image")]
        public string? ImagePath { get; set; }

        // Imagem do Banner
        [StringLength(255)]
        public string? BannerImage { get; set; }

        [StringLength(250)]
        [Display(Name = "Additional Image 1")]
        public string? AdditionalImage1 { get; set; }

        [StringLength(250)]
        [Display(Name = "Additional Image 2")]
        public string? AdditionalImage2 { get; set; }

        [StringLength(250)]
        [Display(Name = "Additional Image 3")]
        public string? AdditionalImage3 { get; set; }

        [StringLength(250)]
        [Display(Name = "Additional Image 4")]
        public string? AdditionalImage4 { get; set; }

        [ForeignKey("Classification")]
        [Required(ErrorMessage = "Select a Classification !")]
        [Display(Name = "Game Classification")]
        public int Classification_Id { get; set; }
        public virtual Classification? Classification { get; set; }

        [ForeignKey("Genre")]
        [Required(ErrorMessage = "Select a Genre !")]
        [Display(Name = "Game Genre")]
        public int Genre_Id { get; set; }
        public virtual Genre? Genre { get; set; }

        [ForeignKey("Genre2")]
        [Display(Name = "Secondary Genre")]
        public int? Genre2_Id { get; set; }
        public virtual Genre? Genre2 { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User? User { get; set; }

        // Adicionando a lista de avaliações
        public virtual List<Review> Reviews { get; set; } = new List<Review>();
    }
}