using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;

namespace MatchFlix.Models
{
    [Table("Avaliacao")] // Especifica o nome da tabela no banco de dados
    public class Avaliacao
    {
        [Key] // Especifica que a propriedade Id_Avaliacao é a chave primária
        public int Id_Avaliacao { get; set; }

        public int Id_Sessao_Filme { get; set; }

        [ForeignKey("Id_Sessao_Filme")] // Propriedade de navegação para a entidade Sessao_Filme
        public virtual SessaoFilme? SessaoFilme { get; set; }

        public int Id_Usuario { get; set; }

        [ForeignKey("Id_Usuario")] // Propriedade de navegação para a entidade Usuarios
        public virtual Usuarios? Usuario { get; set; }

        public bool like { get; set; }

        public DateTime DataHora { get; set; } = DateTime.Now;
    }
}
