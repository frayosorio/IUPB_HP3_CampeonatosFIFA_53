using CampeonatosFIFA.Core.Repositorios;
using CampeonatosFIFA.Dominio.Entidades;
using CampeonatosFIFA.Infraestructura.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;

namespace CampeonatosFIFA.Infraestructura.Repositorios
{
    public class EncuentroRepositorio : IEncuentroRepositorio
    {
        private readonly CampeonatosFifaContext context;
        public EncuentroRepositorio(CampeonatosFifaContext context)
        {
            this.context = context;
        }

        public async Task<Encuentro> Agregar(Encuentro Encuentro)
        {
            context.Encuentros.Add(Encuentro);
            await context.SaveChangesAsync();
            return Encuentro;
        }

        public async Task<IEnumerable<Encuentro>> Buscar(int Tipo, string Dato)
        {
            return await context.Encuentros
                .Where(item => (Tipo == 0 && item.Campeonato.Nombre.Contains(Dato))
                || (Tipo == 1 && (item.Pais1.Nombre.Contains(Dato) || item.Pais2.Nombre.Contains(Dato)))
                || (Tipo == 2 && item.Estadio.Nombre.Contains(Dato))
                || (Tipo == 3 && item.Estadio.Ciudad.Nombre.Contains(Dato))
                )
                .Include(e => e.Pais1)   // Incluir el objeto Pais1
                .Include(e => e.Pais2)   // Incluir el objeto Pais2
                .Include(e => e.Fase)    // Incluir el objeto Fase
                .Include(e => e.Campeonato)  // Incluir el objeto Campeonato
                .Include(e => e.Estadio)     // Incluir el objeto Estadio
                .ToArrayAsync();
        }

        public async Task<bool> Eliminar(int Id)
        {
            var EncuentroExistente = await context.Encuentros.FindAsync(Id);
            if (EncuentroExistente == null)
            {
                return false;
            }
            try
            {
                context.Encuentros.Remove(EncuentroExistente);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Encuentro> Modificar(Encuentro Encuentro)
        {
            var EncuentroExistente = await context.Encuentros.FindAsync(Encuentro.Id);
            if (EncuentroExistente == null)
            {
                return null;
            }

            context.Entry(EncuentroExistente).CurrentValues.SetValues(Encuentro);
            await context.SaveChangesAsync();

            return await context.Encuentros.FindAsync(Encuentro.Id);
        }

        public async Task<Encuentro> Obtener(int Id)
        {
            return await context.Encuentros
                .FindAsync(Id);
        }
        public async Task<IEnumerable<Encuentro>> ObtenerCampeonato(int IdCampeonato)
        {
            return await context.Encuentros
                .Where(item => (item.IdCampeonato == IdCampeonato))
                .Include(e => e.Pais1)   // Incluir el objeto Pais1
                .Include(e => e.Pais2)   // Incluir el objeto Pais2
                .Include(e => e.Fase)    // Incluir el objeto Fase
                .Include(e => e.Campeonato)  // Incluir el objeto Campeonato
                .Include(e => e.Estadio)     // Incluir el objeto Estadio
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Encuentro>> ObtenerCampeonatoFase(int IdCampeonato, int IdFase)
        {
            return await context.Encuentros
                .Where(item => (item.IdCampeonato == IdCampeonato && item.IdFase == IdFase))
                .Include(e => e.Pais1)   // Incluir el objeto Pais1
                .Include(e => e.Pais2)   // Incluir el objeto Pais2
                .Include(e => e.Fase)    // Incluir el objeto Fase
                .Include(e => e.Campeonato)  // Incluir el objeto Campeonato
                .Include(e => e.Estadio)     // Incluir el objeto Estadio
                .ToArrayAsync();

        }

        public async Task<IEnumerable<Encuentro>> ObtenerGrupo(int IdGrupo)
        {
            return await context.Encuentros
               .Where(e => e.IdFase == 1) // Filtrar por fase 1
               .Where(e => context.GrupoPaises
                   .Any(gp => gp.IdGrupo == IdGrupo &&
                             (gp.IdSeleccion == e.IdPais1 || gp.IdSeleccion == e.IdPais2)))
                .Include(e => e.Pais1)   // Incluir el objeto Pais1
                .Include(e => e.Pais2)   // Incluir el objeto Pais2
                .Include(e => e.Fase)    // Incluir el objeto Fase
                .Include(e => e.Campeonato)  // Incluir el objeto Campeonato
                .Include(e => e.Estadio)     // Incluir el objeto Estadio
               .ToArrayAsync();
        }
    }
}
