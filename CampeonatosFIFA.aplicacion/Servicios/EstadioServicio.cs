using CampeonatosFIFA.Core.Repositorios;
using CampeonatosFIFA.Core.Servicios;
using CampeonatosFIFA.Dominio.Entidades;

namespace CampeonatosFIFA.aplicacion.Servicios
{
    public class EstadioServicio : IEstadioServicio
    {
        private readonly IEstadioRepositorio repositorio;

        public EstadioServicio(IEstadioRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<Estadio> Agregar(Estadio Estadio)
        {
            return await repositorio.Agregar(Estadio);
        }

        public async Task<IEnumerable<Estadio>> Buscar(int Tipo, string Dato)
        {
            return await repositorio.Buscar(Tipo, Dato);
        }

        public async Task<bool> Eliminar(int Id)
        {
            return await repositorio.Eliminar(Id);
        }

        public async Task<Estadio> Modificar(Estadio Estadio)
        {
            return await repositorio.Modificar(Estadio);
        }

        public async Task<Estadio> Obtener(int Id)
        {
            return await repositorio.Obtener(Id);
        }

        public async Task<IEnumerable<Estadio>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }
    }
}
