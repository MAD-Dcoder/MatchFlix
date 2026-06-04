using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchFlix.Models
{
    [Table("Genero")]
    public class Genero
    {
        [Key]
        public int Id_Genero { get; set; }

        [Required, MaxLength(100)]
        public string Nome { get; set; } = string.Empty;
    }
}
