using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchFlix.Models
{
    [Table("Filme")] // Garante que o Entity Framework use o nome correto da tabela
    public class Filme
    {
        [Key] // Indica que esta propriedade é a chave primária
        public int Id_Filme { get; set; }

        [Required(ErrorMessage = "O título do filme é obrigatório."), MaxLength(100)] // Validação para garantir que o título seja fornecido
        public string Titulo { get; set; } = string.Empty;

        [Required, MaxLength(1000)]
        public string Sinopse { get; set; } = string.Empty;

        [Required, MaxLength(500)]
        public string Poster_url { get; set; } = string.Empty;

        public int AnoLancamento { get; set; } // Propriedade para armazenar o ano de lançamento do filme

        public int Duracao { get; set; }
    }
}
