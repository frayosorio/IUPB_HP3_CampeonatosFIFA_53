using CampeonatosFIFA.Core.Servicios;
using CampeonatosFIFA.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CampeonatosFIFA.Presentacion.Controllers
{
    [ApiController]
    [Route("api/estadios")]
    public class EstadioControlador : ControllerBase
    {
        private readonly IEstadioServicio servicio;

        public EstadioControlador(IEstadioServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet("listar")]
        public async Task<IEnumerable<Estadio>> ObtenerTodos()
        {
            return await servicio.ObtenerTodos();
        }

        [HttpGet("obtener/{Id}")]
        public async Task<Estadio> Obtener(int Id)
        {
            return await servicio.Obtener(Id);
        }

        [HttpGet("buscar/{Tipo}/{Dato}")]
        public async Task<IEnumerable<Estadio>> Buscar(int Tipo, string Dato)
        {
            return await servicio.Buscar(Tipo, Dato);
        }

        [HttpPost("agregar")]
        public async Task<Estadio> Agregar([FromBody] Estadio Estadio)
        {
            return await servicio.Agregar(Estadio);
        }

        [HttpPut("modificar")]
        public async Task<Estadio> Modificar([FromBody] Estadio Estadio)
        {
            return await servicio.Modificar(Estadio);
        }

        [HttpDelete("eliminar/{Id}")]
        public async Task<bool> Eliminar(int Id)
        {
            return await servicio.Eliminar(Id);
        }

    }
}

