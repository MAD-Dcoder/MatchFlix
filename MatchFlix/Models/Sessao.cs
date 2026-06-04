using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchFlix.Models
{
    [Table("Sessao")] // Garante que o Entity Framework use o nome correto da tabela
    public class Sessao
    {
        [Key] // Define a propriedade Id_Sessao como chave primária
        public int Id_Sessao { get; set; }

        public int Id_Grupo { get; set; }

        [ForeignKey("Id_Grupo")] // Propriedade de navegação para a entidade Grupo_Sessao
        public virtual GrupoSessao? GrupoSessao { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        [Required, MaxLength(100)] // Define a propriedade Status como obrigatória e com um comprimento máximo de 100 caracteres
        public string status { get; set; } = string.Empty; // Exemplo: "Ativa", "Encerrada"
    }
}
