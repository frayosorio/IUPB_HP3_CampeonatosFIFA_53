using CampeonatosFIFA.Core.Repositorios;
using CampeonatosFIFA.Core.Servicios;
using CampeonatosFIFA.Dominio.Entidades;

namespace CampeonatosFIFA.Aplicacion
{
    public class CampeonatoServicio : ICampeonatoServicio
    {
        private readonly ICampeonatoRepositorio repositorio;
        public CampeonatoServicio(ICampeonatoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public Task<Campeonato> Agregar(Campeonato Campeonato)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Campeonato>> Buscar(int Tipo, string Dato)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Campeonato> Modificar(Campeonato Campeonato)
        {
            throw new NotImplementedException();
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
