using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchFlix.Models
{
    [Table("Usuario")] // Garante que o Entity Framework use o nome correto da tabela
    public class Usuarios
    {
        [Key] // Define a propriedade Id_Usuario como chave primária
        public int Id_Usuario { get; set; }

        [Required, MaxLength(100)] // Define a propriedade Nome como obrigatória e com um comprimento máximo de 100 caracteres
        public string Nome { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Senha { get; set; } = string.Empty;

        [Column("data_cadastro")] // <-- COLE AQUI, BEM EM CIMA DA DATA!
        public DateTime DataCadastro { get; set; } = DateTime.Now; // Define a propriedade DataCadastro com um valor padrão...
    }
}
