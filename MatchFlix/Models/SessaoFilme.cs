using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchFlix.Models
{
    [Table("Sessao_Filme")]// Garante que o Entity Framework use o nome correto da tabela
    public class SessaoFilme
    {
        [Key] // Define a propriedade Id_Sessao_Filme como chave primária
        public int Id_Sessao_Filme { get; set; }

        public int Id_Sessao { get; set; }

        [ForeignKey("Id_Sessao")] // Propriedade de navegação para a entidade Sessao
        public virtual Sessao? Sessao { get; set; }

        public int Id_Filme { get; set; }

        [ForeignKey("Id_Filme")] // Propriedade de navegação para a entidade Filme
        public virtual Filme? Filme { get; set; }
    }
}
