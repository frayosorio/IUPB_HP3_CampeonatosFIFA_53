using CampeonatosFIFA.Core.Repositorios;
using CampeonatosFIFA.Core.Servicios;
using CampeonatosFIFA.Dominio.Entidades;

namespace CampeonatosFIFA.aplicacion.Servicios
{
    public class FaseServicio : IFaseServicio
    {
        private readonly IFaseRepositorio repositorio;

        public FaseServicio(IFaseRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<Fase> Agregar(Fase Fase)
        {
            return await repositorio.Agregar(Fase);
        }

        public async Task<IEnumerable<Fase>> Buscar(int Tipo, string Dato)
        {
            return await repositorio.Buscar(Tipo, Dato);
        }

        public async Task<bool> Eliminar(int Id)
        {
            return await repositorio.Eliminar(Id);
        }

        public async Task<Fase> Modificar(Fase Fase)
        {
            return await repositorio.Modificar(Fase);
        }

        public async Task<Fase> Obtener(int Id)
        {
            return await repositorio.Obtener(Id);
        }

        public async Task<IEnumerable<Fase>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }
    }
}
