using CampeonatosFIFA.Core.Servicios;
using CampeonatosFIFA.Dominio.Entidades;
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
        public async Task<IEnumerable<Seleccion>> ObtenerTodos()
        {
            return await servicio.ObtenerTodos();
        }

        [HttpGet("obtener/{Id}")]
        public async Task<Seleccion> Obtener(int Id)
        {
            return await servicio.Obtener(Id);
        }

        [HttpGet("buscar/{Tipo}/{Dato}")]
        public async Task<IEnumerable<Seleccion>> Buscar(int Tipo, string Dato)
        {
            return await servicio.Buscar(Tipo, Dato);
        }

        [HttpPost("agregar")]
        public async Task<Seleccion> Agregar([FromBody]Seleccion seleccion)
        {
            return await servicio.Agregar(seleccion);
        }

        [HttpPut("modificar")]
        public async Task<Seleccion> Modificar([FromBody] Seleccion seleccion)
        {
            return await servicio.Modificar(seleccion);
        }

        [HttpDelete("eliminar/{Id}")]
        public async Task<bool> Eliminar(int Id)
        {
            return await servicio.Eliminar(Id);
        }

    }
}
