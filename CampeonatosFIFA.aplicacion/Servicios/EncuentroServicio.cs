using CampeonatosFIFA.Core.Repositorios;
using CampeonatosFIFA.Core.Servicios;
using CampeonatosFIFA.Dominio.Entidades;

namespace CampeonatosFIFA.aplicacion.Servicios
{
    public class EncuentroServicio : IEncuentroServicio
    {
        private readonly IEncuentroRepositorio repositorio;

        public EncuentroServicio(IEncuentroRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<Encuentro> Agregar(Encuentro Encuentro)
        {
            return await repositorio.Agregar(Encuentro);
        }

        public async Task<IEnumerable<Encuentro>> Buscar(int Tipo, string Dato)
        {
            return await repositorio.Buscar(Tipo, Dato);
        }

        public async Task<bool> Eliminar(int Id)
        {
            return await repositorio.Eliminar(Id);
        }

        public async Task<Encuentro> Modificar(Encuentro Encuentro)
        {
            return await repositorio.Modificar(Encuentro);
        }

        public async Task<Encuentro> Obtener(int Id)
        {
            return await repositorio.Obtener(Id);
        }

        public async Task<IEnumerable<Encuentro>> ObtenerCampeonato(int IdCampeonato)
        {
            return await repositorio.ObtenerCampeonato(IdCampeonato);
        }

        public async Task<IEnumerable<Encuentro>> ObtenerCampeonatoFase(int IdCampeonato, int IdFase)
        {
            return await repositorio.ObtenerCampeonatoFase(IdCampeonato, IdFase);
        }

        public async Task<IEnumerable<Encuentro>> ObtenerGrupo(int IdGrupo)
        {
            return await repositorio.ObtenerGrupo(IdGrupo);
        }


    }
}
