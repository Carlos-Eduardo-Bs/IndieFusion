using System.ComponentModel.DataAnnotations;

namespace IndieFusionFinal.Models
{
    public class NewsModel
    {
        [Key]
        public int Id { get; set; } // Chave primária

        [Required]
        [StringLength(255)] // Limite de caracteres para o título
        public string Title { get; set; }

        [StringLength(1000)] // Limite de caracteres para a descrição
        public string Description { get; set; }

        [Required]
        [Url] // Validação para garantir que seja uma URL válida
        public string Url { get; set; }

        [Url] // Validação para garantir que seja uma URL válida
        public string UrlToImage { get; set; }

        [Required]
        public DateTime PublishedAt { get; set; } // Data de publicação

        public string SourceId { get; set; } // ID da fonte
        public string SourceName { get; set; } // Nome da fonte
    }
}
