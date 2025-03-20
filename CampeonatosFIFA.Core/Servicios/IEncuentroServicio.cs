using CampeonatosFIFA.Dominio.Entidades;

namespace CampeonatosFIFA.Core.Servicios
{
    public interface IEncuentroServicio
    {
        Task<IEnumerable<Encuentro>> ObtenerTodos();

        Task<Encuentro> Obtener(int Id);

        Task<Encuentro> Agregar(Encuentro Encuentro);

        Task<Encuentro> Modificar(Encuentro Encuentro);

        Task<bool> Eliminar(int Id);

        Task<IEnumerable<Encuentro>> Buscar(int Tipo, string Dato);
    }
}
