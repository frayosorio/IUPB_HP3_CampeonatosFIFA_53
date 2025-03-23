using CampeonatosFIFA.Core.Servicios;
using CampeonatosFIFA.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CampeonatosFIFA.Presentacion.Controllers
{
    [ApiController]
    [Route("api/encuentros")]
    public class EncuentroControlador : ControllerBase
    {
        private readonly IEncuentroServicio servicio;

        public EncuentroControlador(IEncuentroServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet("obtener/{Id}")]
        public async Task<Encuentro> Obtener(int Id)
        {
            return await servicio.Obtener(Id);
        }

        [HttpGet("buscar/{Tipo}/{Dato}")]
        public async Task<IEnumerable<Encuentro>> Buscar(int Tipo, string Dato)
        {
            return await servicio.Buscar(Tipo, Dato);
        }

        [HttpPost("agregar")]
        public async Task<Encuentro> Agregar([FromBody] Encuentro Encuentro)
        {
            return await servicio.Agregar(Encuentro);
        }

        [HttpPut("modificar")]
        public async Task<Encuentro> Modificar([FromBody] Encuentro Encuentro)
        {
            return await servicio.Modificar(Encuentro);
        }

        [HttpDelete("eliminar/{Id}")]
        public async Task<bool> Eliminar(int Id)
        {
            return await servicio.Eliminar(Id);
        }

        [HttpGet("listarcampeonato/{IdCampeonato}")]
        public async Task<IEnumerable<Encuentro>> ObtenerCampeonato(int IdCampeonato)
        {
            return await servicio.ObtenerCampeonato(IdCampeonato);
        }

        [HttpGet("listarcampeonatofase/{IdCampeonato}/{IdFase}")]
        public async Task<IEnumerable<Encuentro>> ObtenerCampeonatoFase(int IdCampeonato, int IdFase)
        {
            return await servicio.ObtenerCampeonatoFase(IdCampeonato, IdFase);
        }

        [HttpGet("listargrupo/{IdGrupo}")]
        public async Task<IEnumerable<Encuentro>> ObtenerGrupo(int IdGrupo)
        {
            return await servicio.ObtenerGrupo(IdGrupo);
        }

    }
}