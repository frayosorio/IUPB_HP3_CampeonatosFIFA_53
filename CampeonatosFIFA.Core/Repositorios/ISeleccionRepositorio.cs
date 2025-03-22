using CampeonatosFIFA.Dominio.Entidades;

namespace CampeonatosFIFA.Core.Repositorios
{
    public interface ISeleccionRepositorio
    {
        Task<IEnumerable<Seleccion>> ObtenerTodos();

        Task<Seleccion> Obtener(int Id);

        Task<IEnumerable<Seleccion>> Buscar(int Tipo, string Dato);

        Task<Seleccion> Agregar(Seleccion seleccion);

        Task<Seleccion> Modificar(Seleccion seleccion);

        Task<bool> Eliminar(int Id);


    }
}
