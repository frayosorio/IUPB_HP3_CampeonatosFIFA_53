using CampeonatosFIFA.Core.Servicios;
using CampeonatosFIFA.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CampeonatosFIFA.Presentacion.Controllers
{
    [ApiController]
    [Route("api/ciudades")]
    public class CiudadControlador : ControllerBase
    {
        private readonly ICiudadServicio servicio;

        public CiudadControlador(ICiudadServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet("listar")]
        public async Task<IEnumerable<Ciudad>> ObtenerTodos()
        {
            return await servicio.ObtenerTodos();
        }

        [HttpGet("obtener/{Id}")]
        public async Task<Ciudad> Obtener(int Id)
        {
            return await servicio.Obtener(Id);
        }

        [HttpGet("buscar/{Tipo}/{Dato}")]
        public async Task<IEnumerable<Ciudad>> Buscar(int Tipo, string Dato)
        {
            return await servicio.Buscar(Tipo, Dato);
        }

        [HttpPost("agregar")]
        public async Task<Ciudad> Agregar([FromBody] Ciudad Ciudad)
        {
            return await servicio.Agregar(Ciudad);
        }

        [HttpPut("modificar")]
        public async Task<Ciudad> Modificar([FromBody] Ciudad Ciudad)
        {
            return await servicio.Modificar(Ciudad);
        }

        [HttpDelete("eliminar/{Id}")]
        public async Task<bool> Eliminar(int Id)
        {
            return await servicio.Eliminar(Id);
        }

    }
}
