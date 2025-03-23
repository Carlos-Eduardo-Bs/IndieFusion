using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IndieFusionFinal.Models

{


    [Table("Review")]
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Game")]
        public int GameId { get; set; }
        public virtual Game? Game { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User? User { get; set; }

        public bool Like { get; set; } // True = Like, False = Deslike

        [StringLength(500)]
        public string? Comment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }


}
