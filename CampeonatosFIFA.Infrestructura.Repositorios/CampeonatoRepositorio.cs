using CampeonatosFIFA.Core.Repositorios;
using CampeonatosFIFA.Dominio.Entidades;
using CampeonatosFIFA.Infraestructura.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;

namespace CampeonatosFIFA.Infraestructura.Repositorios
{
    public class CampeonatoRepositorio : ICampeonatoRepositorio
    {
        private readonly CampeonatosFifaContext context;
        public CampeonatoRepositorio(CampeonatosFifaContext context)
        {
            this.context = context;
        }

        public async Task<Campeonato> Agregar(Campeonato Campeonato)
        {
            context.Campeonatos.Add(Campeonato);
            await context.SaveChangesAsync();
            return Campeonato;
        }

        public async Task<IEnumerable<Campeonato>> Buscar(int Tipo, string Dato)
        {
            return await context.Campeonatos
                .Where(item => (Tipo == 0 && item.Nombre.Contains(Dato))
                || (Tipo == 1 && item.Año.ToString()==Dato)
                || (Tipo == 2 && item.PaisOrganizador.Nombre.Contains(Dato)))
                .Include(e => e.PaisOrganizador)   // Incluir el objeto Pais Organizador
                .ToArrayAsync();
        }

        public async Task<bool> Eliminar(int Id)
        {
            var CampeonatoExistente = await context.Campeonatos.FindAsync(Id);
            if (CampeonatoExistente == null)
            {
                return false;
            }
            try
            {
                context.Campeonatos.Remove(CampeonatoExistente);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Campeonato> Modificar(Campeonato Campeonato)
        {
            var CampeonatoExistente = await context.Campeonatos.FindAsync(Campeonato.Id);
            if (CampeonatoExistente == null)
            {
                return null;
            }

            context.Entry(CampeonatoExistente).CurrentValues.SetValues(Campeonato);
            await context.SaveChangesAsync();

            return await context.Campeonatos.FindAsync(Campeonato.Id);
        }

        public async Task<Campeonato> Obtener(int Id)
        {
            return await context.Campeonatos.FindAsync(Id);
        }

        public async Task<IEnumerable<Campeonato>> ObtenerTodos()
        {
            return await context.Campeonatos
                .Include(e => e.PaisOrganizador)   // Incluir el objeto Pais Organizador
                .ToArrayAsync();
        }
    }
}
