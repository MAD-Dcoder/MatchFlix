using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchFlix.Models
{
    [Table("Match")] // Garante que o Entity Framework use o nome correto da tabela
    public class Match
    {
        [Key] // Define a propriedade id_match como chave primária
        public int id_match { get; set; }

        public int Id_Sessao { get; set; }

        [ForeignKey("Id_Sessao")] // Propriedade de navegação para a entidade Sessao
        public virtual Sessao? Sessao { get; set; }

        public int Id_Filme { get; set; }

        [ForeignKey("Id_Filme")] // Propriedade de navegação para a entidade Filme
        public virtual Filme? Filme { get; set; }

        public int Total_Likes { get; set; }

        public DateTime DataMacth { get; set; }
    }
}
