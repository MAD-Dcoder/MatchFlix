using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchFlix.Models
{
    [Table("Grupo_Sessao")] // Garante que o Entity Framework use o nome correto da tabela
    public class GrupoSessao
    {
        [Key] // Define a propriedade Id_Grupo como chave primária
        public int Id_Grupo { get; set; }

        [Required, MaxLength(100)] // Define a propriedade Nome_Grupo como obrigatória e com um comprimento máximo de 100 caracteres
        public string Nome_Grupo { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string CodigoConvite { get; set; } = string.Empty;

        [Required, MaxLength(500)]
        public string Descricao { get; set; } = string.Empty;

        public DateTime DataCriaçao { get; set; }

        public int Id_Usuario_Criador { get; set; }

        [ForeignKey("Id_Usuario_Criador")]
        public virtual Usuarios? UsuariosCriador { get; set; }
    }
}
