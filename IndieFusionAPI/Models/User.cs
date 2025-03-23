using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndieFusionAPI.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int IdUser { get; set; }

        [Required]
        [Column("Name")]
        public string Name { get; set; }

        [Required]
        [Column("NickName")]
        public string NickName { get; set; }

        [Required]
        [Column("Email")]
        public string Email { get; set; }

        [Required]
        [Column("Password")]
        public string Password { get; set; }

        [Required]
        [Column("BirthDate")]
        public DateTime BirthDate { get; set; }

        [StringLength(250)]
        [Display(Name = "Image")]
        public string? ImagePath { get; set; }

        [ForeignKey("UserType")]
        [Required(ErrorMessage = "Select a UserType !")]
        public int UserTp { get; set; }
        public virtual UserType? UserType { get; set; }

        // Propriedade calculada para exibir a descrição do UserType
        [NotMapped] // não mapeia no banco
        public string UserTypeDescription
        {
            get { return UserType != null ? UserType.Description : string.Empty; }
        }

    }
}
