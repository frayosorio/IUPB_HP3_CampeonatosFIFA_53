using CampeonatosFIFA.Core.Repositorios;
using CampeonatosFIFA.Dominio.DTOs;
using CampeonatosFIFA.Dominio.Entidades;
using CampeonatosFIFA.Infraestructura.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;

namespace CampeonatosFIFA.Infraestructura.Repositorios
{
    public class GrupoRepositorio : IGrupoRepositorio
    {
        private readonly CampeonatosFifaContext context;
        public GrupoRepositorio(CampeonatosFifaContext context)
        {
            this.context = context;
        }

        public async Task<Grupo> Agregar(Grupo Grupo)
        {
            context.Grupos.Add(Grupo);
            await context.SaveChangesAsync();
            return Grupo;
        }

        public async Task<IEnumerable<Grupo>> Buscar(int Tipo, string Dato)
        {
            return await context.Grupos
                .Where(item => (Tipo == 0 && item.Nombre.Contains(Dato))
                || (Tipo == 1 && item.Campeonato.Nombre.Contains(Dato)))
                .Include(e => e.Campeonato)   // Incluir el objeto Campeonato
                    .ThenInclude(c => c.PaisOrganizador) // Incluir el País Organizador
                .ToArrayAsync();
        }

        public async Task<bool> Eliminar(int Id)
        {
            var GrupoExistente = await context.Grupos.FindAsync(Id);
            if (GrupoExistente == null)
            {
                return false;
            }
            try
            {
                context.Grupos.Remove(GrupoExistente);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Grupo> Modificar(Grupo Grupo)
        {
            var GrupoExistente = await context.Grupos.FindAsync(Grupo.Id);
            if (GrupoExistente == null)
            {
                return null;
            }

            context.Entry(GrupoExistente).CurrentValues.SetValues(Grupo);
            await context.SaveChangesAsync();

            return await context.Grupos.FindAsync(Grupo.Id);
        }

        public async Task<Grupo> Obtener(int Id)
        {
            return await context.Grupos.FindAsync(Id);
        }

        public async Task<IEnumerable<Grupo>> ObtenerTodos()
        {
            return await context.Grupos
                .Include(e => e.Campeonato)   // Incluir el objeto Campeonato
                    .ThenInclude(c => c.PaisOrganizador) // Incluir el País Organizador
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Grupo>> ObtenerCampeonato(int IdCampeonato)
        {
            return await context.Grupos
                .Where(item => (item.IdCampeonato == IdCampeonato))
                .Include(e => e.Campeonato)   // Incluir el objeto Campeonato
                    .ThenInclude(c => c.PaisOrganizador) // Incluir el País Organizador
                .ToArrayAsync();
        }

        //***** Tabla de Posiciones *****

        public async Task<IEnumerable<TablaPosicionesDto>> ObtenerTablaPosicionesGrupo(int IdGrupo)
        {
            return await context.ObtenerTablaPosicionesGrupo(IdGrupo);
        }
    }
}
