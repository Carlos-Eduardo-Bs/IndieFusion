using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndieFusionDesk.Models
{
    [Table("User")] // se estiver usando EF no desktop, caso contrário não precisa
    public class User
    {

        public int IdUser { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "NickName is required")]
        public string NickName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "BirthDate is required")]
        public DateTime BirthDate { get; set; }

        public string? ImagePath { get; set; }

        [Required(ErrorMessage = "UserType is required")]
        public int UserTp { get; set; }

        public UserType UserType { get; set; }



        // Propriedade calculada: mostra o texto do UserType
        // Em caso de nulo, retorna vazio (ou outro texto)
        [NotMapped]
        public string DisplayUserType
        {
            get
            {
                return UserType?.Description ?? "";
            }
        }
    }
}
