using CampeonatosFIFA.Core.Repositorios;
using CampeonatosFIFA.Core.Servicios;
using CampeonatosFIFA.Dominio.DTOs;
using CampeonatosFIFA.Dominio.Entidades;

namespace CampeonatosFIFA.aplicacion.Servicios
{
    public class GrupoServicio : IGrupoServicio
    {
        private readonly IGrupoRepositorio repositorio;
        private readonly IGrupoPaisRepositorio repositorioPaises;

        public GrupoServicio(IGrupoRepositorio repositorio, IGrupoPaisRepositorio repositorioPaises)
        {
            this.repositorio = repositorio;
            this.repositorioPaises = repositorioPaises;
        }

        public async Task<Grupo> Agregar(Grupo Grupo)
        {
            return await repositorio.Agregar(Grupo);
        }

        public async Task<IEnumerable<Grupo>> Buscar(int Tipo, string Dato)
        {
            return await repositorio.Buscar(Tipo, Dato);
        }

        public async Task<bool> Eliminar(int Id)
        {
            return await repositorio.Eliminar(Id);
        }

        public async Task<Grupo> Modificar(Grupo Grupo)
        {
            return await repositorio.Modificar(Grupo);
        }

        public async Task<Grupo> Obtener(int Id)
        {
            return await repositorio.Obtener(Id);
        }

        public async Task<IEnumerable<Grupo>> ObtenerCampeonato(int IdCampeonato)
        {
            return await repositorio.ObtenerCampeonato(IdCampeonato);
        }

        public async Task<IEnumerable<Grupo>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }

        //***** Paises del Grupo *****

        public async Task<GrupoPais> AgregarPais(GrupoPais GrupoPais)
        {
            return await repositorioPaises.Agregar(GrupoPais);
        }

        public async Task<bool> EliminarPais(int IdGrupo, int IdPais)
        {
            return await repositorioPaises.Eliminar(IdGrupo, IdPais);
        }

        public async Task<GrupoPais> ModificarPais(GrupoPais GrupoPais)
        {
            return await repositorioPaises.Modificar(GrupoPais);
        }

        public async Task<GrupoPais> ObtenerPais(int IdGrupo, int IdPais)
        {
            return await repositorioPaises.Obtener(IdGrupo, IdPais);
        }

        public async Task<IEnumerable<GrupoPais>> ObtenerPaises(int IdGrupo)
        {
            return await repositorioPaises.ObtenerPaises(IdGrupo);
        }

        //***** Tabla de Posiciones *****

        public async Task<IEnumerable<TablaPosicionesDto>> ObtenerTablaPosicionesGrupo(int IdGrupo)
        {
            return await repositorio.ObtenerTablaPosicionesGrupo(IdGrupo);
        }
    }
}
