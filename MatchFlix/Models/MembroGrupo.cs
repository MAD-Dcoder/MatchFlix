using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchFlix.Models
{
    [Table("Membro_Grupo")]
    public class MembroGrupo
    {
        [Key]// Define a propriedade Id_Membro_Grupo como chave primária
        public int Id_Membro_Grupo { get; set; }

        public int Id_Grupo { get; set; }

        [ForeignKey("Id_Grupo")]// Propriedade de navegação para a entidade Grupo_Sessao
        public virtual GrupoSessao? GrupoSessao { get; set; }

        public int Id_Usuario { get; set; }

        [ForeignKey("Id_Usuario")]// Propriedade de navegação para a entidade Usuarios
        public virtual Usuarios? Usuario { get; set; }

        public DateTime DataEntrada { get; set; }

        [Required, MaxLength(100)]
        public string Papel { get; set; } = string.Empty; // Exemplo: "Membro", "Administrador"
    }
}
