using CampeonatosFIFA.Core.Servicios;
using CampeonatosFIFA.Dominio.DTOs;
using CampeonatosFIFA.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CampeonatosFIFA.Presentacion.Controllers
{
    [ApiController]
    [Route("api/grupos")]
    public class GrupoControlador : ControllerBase
    {
        private readonly IGrupoServicio servicio;

        public GrupoControlador(IGrupoServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpPost("agregar")]
        public async Task<Grupo> Agregar(Grupo Grupo)
        {
            return await servicio.Agregar(Grupo);
        }

        [HttpGet("buscar/{Tipo}/{Dato}")]
        public async Task<IEnumerable<Grupo>> Buscar(int Tipo, string Dato)
        {
            return await servicio.Buscar(Tipo, Dato);
        }

        [HttpDelete("eliminar/{Id}")]
        public async Task<bool> Eliminar(int Id)
        {
            return await servicio.Eliminar(Id);
        }

        [HttpPut("modificar")]
        public async Task<Grupo> Modificar(Grupo Grupo)
        {
            return await servicio.Modificar(Grupo);
        }

        [HttpGet("obtener/{Id}")]
        public async Task<Grupo> Obtener(int Id)
        {
            return await servicio.Obtener(Id);
        }

        [HttpGet("listarcampeonato/{IdCampeonato}")]
        public async Task<IEnumerable<Grupo>> ObtenerCampeonato(int IdCampeonato)
        {
            return await servicio.ObtenerCampeonato(IdCampeonato);
        }

        [HttpGet("listar")]
        public async Task<IEnumerable<Grupo>> ObtenerTodos()
        {
            return await servicio.ObtenerTodos();
        }

        //***** Paises del Grupo *****

        [HttpPut("agregarpais")]
        public async Task<GrupoPais> AgregarPais([FromBody] GrupoPais GrupoPais)
        {
            return await servicio.AgregarPais(GrupoPais);
        }

        [HttpDelete("eliminarpais/{IdGrupo}/{IdPais}")]
        public async Task<bool> EliminarPais(int IdGrupo, int IdPais)
        {
            return await servicio.EliminarPais(IdGrupo, IdPais);
        }

        [HttpPut("modificarpais")]
        public async Task<GrupoPais> ModificarPais([FromBody] GrupoPais GrupoPais)
        {
            return await servicio.ModificarPais(GrupoPais);
        }

        [HttpGet("obtenerpais/{IdGrupo}/{IdPais}")]
        public async Task<GrupoPais> ObtenerPais(int IdGrupo, int IdPais)
        {
            return await servicio.ObtenerPais(IdGrupo, IdPais);
        }

        [HttpGet("listarpaises/{IdGrupo}")]
        public async Task<IEnumerable<GrupoPais>> ObtenerPaises(int IdGrupo)
        {
            return await servicio.ObtenerPaises(IdGrupo);
        }

        //***** Tabla de Posiciones *****

        [HttpGet("posiciones/{IdGrupo}")]
        public async Task<IEnumerable<TablaPosicionesDto>> ObtenerTablaPosicionesGrupo(int IdGrupo)
        {
            return await servicio.ObtenerTablaPosicionesGrupo(IdGrupo);
        }
    }
}