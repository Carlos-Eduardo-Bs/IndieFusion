using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("UserType")]
public class UserType
{
    [Key]
    [Column("Id")]
    public int Id { get; set; } 

    [Required]
    [Column("Description")]
    public string Description { get; set; }
}
