using CampeonatosFIFA.Core.Repositorios;
using CampeonatosFIFA.Core.Servicios;
using CampeonatosFIFA.Dominio.Entidades;

namespace CampeonatosFIFA.aplicacion.Servicios
{
    public class CiudadServicio : ICiudadServicio
    {
        private readonly ICiudadRepositorio repositorio;

        public CiudadServicio(ICiudadRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<Ciudad> Agregar(Ciudad Ciudad)
        {
            return await repositorio.Agregar(Ciudad);
        }

        public async Task<IEnumerable<Ciudad>> Buscar(int Tipo, string Dato)
        {
            return await repositorio.Buscar(Tipo, Dato);
        }

        public async Task<bool> Eliminar(int Id)
        {
            return await repositorio.Eliminar(Id);
        }

        public async Task<Ciudad> Modificar(Ciudad Ciudad)
        {
            return await repositorio.Modificar(Ciudad);
        }

        public async Task<Ciudad> Obtener(int Id)
        {
            return await repositorio.Obtener(Id);
        }

        public async Task<IEnumerable<Ciudad>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }
    }
}
