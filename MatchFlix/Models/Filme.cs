using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchFlix.Models
{
    [Table("FILME")]
    public class Filme
    {
        [Key]
        [Column("id_filme")]
        public int Id_Filme { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("titulo")]
        public string Titulo { get; set; } = string.Empty;

        [Column("sinopse")]
        public string? Sinopse { get; set; } // O '?' permite nulo e evita erro de cast

        [Column("url_capa")]
        public string? Poster_url { get; set; }

        [Column("ano_lancamento")]
        public int? AnoLancamento { get; set; }

        [Column("duracao")]
        public int? Duracao { get; set; }
    }
}