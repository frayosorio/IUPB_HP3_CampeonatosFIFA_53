using CampeonatosFIFA.Dominio.Entidades;

namespace CampeonatosFIFA.Core.Repositorios
{
    internal interface IFaseRepositorio
    {
        Task<IEnumerable<Fase>> ObtenerTodos();

        Task<Fase> Obtener(int Id);

        Task<Fase> Agregar(Fase Fase);

        Task<Fase> Modificar(Fase Fase);

        Task<bool> Eliminar(int Id);

        Task<IEnumerable<Fase>> Buscar(int Tipo, string Dato);
    }
}
