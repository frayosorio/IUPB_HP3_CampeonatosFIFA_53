using CampeonatosFIFA.Core.Repositorios;
using CampeonatosFIFA.Core.Servicios;
using CampeonatosFIFA.Dominio.Entidades;
using CampeonatosFIFA.Persistencia.Contexto;

namespace CampeonatosFIFA.aplicacion
{
    public class SeleccionServicio : ISeleccionServicio
    {
        private readonly ISeleccionRepositorio repositorio;

        public SeleccionServicio(ISeleccionRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public Task<Seleccion> Agregar(Seleccion Seleccion)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Seleccion>> Buscar(int Tipo, string Dato)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Seleccion> Modificar(Seleccion Seleccion)
        {
            throw new NotImplementedException();
        }

        public async Task<Seleccion> Obtener(int Id)
        {
            return await repositorio.Obtener(Id);
        }

        public async Task<IEnumerable<Seleccion>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }
    }
}
