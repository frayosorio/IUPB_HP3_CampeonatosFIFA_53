using CampeonatosFIFA.Dominio.Entidades;

namespace CampeonatosFIFA.Core.Servicios
{
    public interface IGrupoServicio
    {
        Task<IEnumerable<Grupo>> ObtenerTodos();

        Task<IEnumerable<Grupo>> ObtenerCampeonato(int IdCampeonato);

        Task<Grupo> Obtener(int Id);

        Task<Grupo> Agregar(Grupo Grupo);

        Task<Grupo> Modificar(Grupo Grupo);

        Task<bool> Eliminar(int Id);

        Task<IEnumerable<Grupo>> Buscar(int Tipo, string Dato);

        //***** Paises del Grupo *****

        Task<IEnumerable<GrupoPais>> ObtenerPaises(int IdGrupo);

        Task<GrupoPais> ObtenerPais(int IdGrupo, int IdPais);

        Task<GrupoPais> AgregarPais(GrupoPais GrupoPais);

        Task<GrupoPais> ModificarPais(GrupoPais GrupoPais);

        Task<bool> EliminarPais(int IdGrupo, int IdPais);

        //***** Tabla de Posiciones *****

    }
}
