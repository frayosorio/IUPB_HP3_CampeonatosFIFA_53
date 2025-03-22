using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CampeonatosFIFA.Dominio.Entidades
{
    [Table("Fase")]
    public class Fase
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Fase"), StringLength(50)]
        public required string Nombre { get; set; }
    }
}
