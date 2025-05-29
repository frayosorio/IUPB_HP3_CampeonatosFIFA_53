using CampeonatosFIFA.Core.Servicios;
using CampeonatosFIFA.Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CampeonatosFIFA.Presentacion.Controllers
{
    [ApiController]
    [Route("api/selecciones")]
    public class SeleccionControlador : ControllerBase
    {
        private readonly ISeleccionServicio servicio;

        public SeleccionControlador(ISeleccionServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet("listar")]
        [Authorize]
        public async Task<IEnumerable<Seleccion>> ObtenerTodos()
        {
            return await servicio.ObtenerTodos();
        }

        [HttpGet("obtener/{Id}")]
        [Authorize]
        public async Task<Seleccion> Obtener(int Id)
        {
            return await servicio.Obtener(Id);
        }

        [HttpGet("buscar/{Tipo}/{Dato}")]
        [Authorize]
        public async Task<IEnumerable<Seleccion>> Buscar(int Tipo, string Dato)
        {
            return await servicio.Buscar(Tipo, Dato);
        }

        [HttpPost("agregar")]
        [Authorize]
        public async Task<Seleccion> Agregar([FromBody]Seleccion seleccion)
        {
            return await servicio.Agregar(seleccion);
        }

        [HttpPut("modificar")]
        [Authorize]
        public async Task<Seleccion> Modificar([FromBody] Seleccion seleccion)
        {
            return await servicio.Modificar(seleccion);
        }

        [HttpDelete("eliminar/{Id}")]
        [Authorize]
        public async Task<bool> Eliminar(int Id)
        {
            return await servicio.Eliminar(Id);
        }

    }
}
