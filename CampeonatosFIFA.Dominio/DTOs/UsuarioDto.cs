using CampeonatosFIFA.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatosFIFA.Dominio.DTOs
{
    public class UsuarioDto
    {
        public Usuario usuario { get; set; }
        public String token { get; set; }
    }
}
