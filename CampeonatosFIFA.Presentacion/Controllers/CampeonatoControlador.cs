using CampeonatosFIFA.Core.Servicios;
using CampeonatosFIFA.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CampeonatosFIFA.Presentacion.Controllers
{
    [ApiController]
    [Route("api/campeonatos")]
    public class CampeonatoControlador : ControllerBase
    {
        private readonly ICampeonatoServicio servicio;

        public CampeonatoControlador(ICampeonatoServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet("listar")]
        public async Task<IEnumerable<Campeonato>> ObtenerTodos()
        {
            return await servicio.ObtenerTodos();
        }

        [HttpGet("obtener/{Id}")]
        public async Task<Campeonato> Obtener(int Id)
        {
            return await servicio.Obtener(Id);
        }

        [HttpGet("buscar/{Tipo}/{Dato}")]
        public async Task<IEnumerable<Campeonato>> Buscar(int Tipo, string Dato)
        {
            return await servicio.Buscar(Tipo, Dato);
        }

        [HttpPost("agregar")]
        public async Task<Campeonato> Agregar([FromBody] Campeonato Campeonato)
        {
            return await servicio.Agregar(Campeonato);
        }

        [HttpPut("modificar")]
        public async Task<Campeonato> Modificar([FromBody] Campeonato Campeonato)
        {
            return await servicio.Modificar(Campeonato);
        }

        [HttpDelete("eliminar/{Id}")]
        public async Task<bool> Eliminar(int Id)
        {
            return await servicio.Eliminar(Id);
        }

    }
}
