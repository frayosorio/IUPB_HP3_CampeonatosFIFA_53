using CampeonatosFIFA.Dominio.Entidades;

namespace CampeonatosFIFA.Core.Servicios
{
    internal interface IGrupoServicio
    {
        Task<IEnumerable<Grupo>> ObtenerTodos();

        Task<Grupo> Obtener(int Id);

        Task<Grupo> Agregar(Grupo Grupo);

        Task<Grupo> Modificar(Grupo Grupo);

        Task<bool> Eliminar(int Id);

        Task<IEnumerable<Grupo>> Buscar(int Tipo, string Dato);


        Task<IEnumerable<GrupoPais>> ObtenerPaises(int IdGrupo);

        Task<GrupoPais> ObtenerPais(int IdGrupo, int IdPais);

        Task<GrupoPais> AgregarPais(GrupoPais GrupoPais);

        Task<GrupoPais> ModificarPais(GrupoPais GrupoPais);

        Task<bool> EliminarPais(int IdGrupo, int IdPais);
    }
}
