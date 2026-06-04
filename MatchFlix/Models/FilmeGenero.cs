using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchFlix.Models
{
    [Table("Filme_Genero")] // Garante que o Entity Framework use o nome correto da tabela
    public class FilmeGenero
    {
        public int Id_Filme { get; set; }

        [ForeignKey("Id_Filme")]
        public virtual Filme? Filme { get; set; } // Propriedade de navegação para a entidade Filme

        public int Id_Genero { get; set; }

        [ForeignKey("Id_Genero")]
        public virtual Genero? Genero { get; set; } // Propriedade de navegação para a entidade Genero

    }
}
