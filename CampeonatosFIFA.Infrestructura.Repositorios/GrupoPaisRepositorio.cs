using CampeonatosFIFA.Core.Repositorios;
using CampeonatosFIFA.Dominio.Entidades;
using CampeonatosFIFA.Infraestructura.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;

namespace CampeonatosFIFA.Infraestructura.Repositorios
{
    public class GrupoPaisRepositorio : IGrupoPaisRepositorio
    {
        private readonly CampeonatosFifaContext context;
        public GrupoPaisRepositorio(CampeonatosFifaContext context)
        {
            this.context = context;
        }

        public async Task<GrupoPais> Agregar(GrupoPais GrupoPais)
        {
            context.GrupoPaises.Add(GrupoPais);
            await context.SaveChangesAsync();
            return GrupoPais;
        }

        public async Task<bool> Eliminar(int IdGrupo, int IdPais)
        {
            var GrupoPaisExistente = await context.GrupoPaises.FindAsync(IdGrupo, IdPais);
            if (GrupoPaisExistente == null)
            {
                return false;
            }
            try
            {
                context.GrupoPaises.Remove(GrupoPaisExistente);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<GrupoPais> Modificar(GrupoPais GrupoPais)
        {
            var GrupoPaisExistente = await context.GrupoPaises.FindAsync(GrupoPais.IdGrupo, GrupoPais.IdSeleccion);
            if (GrupoPaisExistente == null)
            {
                return null;
            }

            context.Entry(GrupoPaisExistente).CurrentValues.SetValues(GrupoPais);
            await context.SaveChangesAsync();

            return await context.GrupoPaises.FindAsync(GrupoPais.IdGrupo, GrupoPais.IdSeleccion);
        }

        public async Task<GrupoPais> Obtener(int IdGrupo, int IdPais)
        {
            return await context.GrupoPaises.FindAsync(IdGrupo, IdPais);
        }

        public async Task<IEnumerable<GrupoPais>> ObtenerPaises(int IdGrupo)
        {
            return await context.GrupoPaises
                .Where(item => item.IdGrupo == IdGrupo)
                .Include(e => e.Grupo)   // Incluir el objeto Grupo
                .Include(e => e.Seleccion)   // Incluir el objeto Seleccion
                .ToArrayAsync();
        }
    }
}
