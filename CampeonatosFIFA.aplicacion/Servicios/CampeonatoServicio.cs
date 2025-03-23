using CampeonatosFIFA.Core.Repositorios;
using CampeonatosFIFA.Core.Servicios;
using CampeonatosFIFA.Dominio.Entidades;

namespace CampeonatosFIFA.aplicacion.Servicios
{
    public class CampeonatoServicio : ICampeonatoServicio
    {
        private readonly ICampeonatoRepositorio repositorio;
        public CampeonatoServicio(ICampeonatoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }


        public async Task<Campeonato> Agregar(Campeonato Campeonato)
        {
            return await repositorio.Agregar(Campeonato);
        }

        public async Task<IEnumerable<Campeonato>> Buscar(int Tipo, string Dato)
        {
            return await repositorio.Buscar(Tipo, Dato);
        }

        public async Task<bool> Eliminar(int Id)
        {
            return await repositorio.Eliminar(Id);
        }

        public async Task<Campeonato> Modificar(Campeonato Campeonato)
        {
            return await repositorio.Modificar(Campeonato);
        }

        public async Task<Campeonato> Obtener(int Id)
        {
            return await repositorio.Obtener(Id);
        }

        public async Task<IEnumerable<Campeonato>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }


    }
}
