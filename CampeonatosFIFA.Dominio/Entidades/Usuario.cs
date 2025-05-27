using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatosFIFA.Dominio.Entidades
{
    [Table("Usuario")]
    public class Usuario
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nombre"), StringLength(100)]
        public required string Nombre { get; set; }

        [Column("Usuario"), StringLength(100)]
        public required string NombreUsuario { get; set; }

        [Column("Clave"), StringLength(100)]
        public required string Clave { get; set; }

        [Column("Roles"), StringLength(100)]
        public string Roles { get; set; }
    }
}
