using CampeonatosFIFA.Dominio.Entidades;

namespace CampeonatosFIFA.Core.Repositorios
{
    public  interface IGrupoPaisRepositorio
    {
        Task<IEnumerable<GrupoPais>> ObtenerPaises(int IdGrupo);

        Task<GrupoPais> Obtener(int IdGrupo, int IdPais);

        Task<GrupoPais> Agregar(GrupoPais GrupoPais);

        Task<GrupoPais> Modificar(GrupoPais GrupoPais);

        Task<bool> Eliminar(int IdGrupo, int IdPais);

    }
}
