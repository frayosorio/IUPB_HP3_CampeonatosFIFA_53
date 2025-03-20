using CampeonatosFIFA.Dominio.Entidades;

namespace EncuentrosFIFA.Core.Repositorios
{
    public interface IEncuentroRepositorio
    {
        Task<IEnumerable<Encuentro>> ObtenerTodos();

        Task<Encuentro> Obtener(int Id);

        Task<Encuentro> Agregar(Encuentro Encuentro);

        Task<Encuentro> Modificar(Encuentro Encuentro);

        Task<bool> Eliminar(int Id);

        Task<IEnumerable<Encuentro>> Buscar(int Tipo, string Dato);
    }
}
