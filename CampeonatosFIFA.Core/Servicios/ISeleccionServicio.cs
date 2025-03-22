using CampeonatosFIFA.Dominio.Entidades;

namespace CampeonatosFIFA.Core.Servicios
{
    public interface ISeleccionServicio
    {
        Task<IEnumerable<Seleccion>> ObtenerTodos();

        Task<Seleccion> Obtener(int Id);

        Task<IEnumerable<Seleccion>> Buscar(int Tipo, string Dato);

        Task<Seleccion> Agregar(Seleccion Seleccion);

        Task<Seleccion> Modificar(Seleccion Seleccion);

        Task<bool> Eliminar(int Id);
    }
}
