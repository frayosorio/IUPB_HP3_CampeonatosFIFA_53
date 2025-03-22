using CampeonatosFIFA.Core.Repositorios;
using CampeonatosFIFA.Dominio.Entidades;
using CampeonatosFIFA.Infraestructura.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;

namespace CampeonatosFIFA.Infraestructura.Repositorios
{
    public class EstadioRepositorio : IEstadioRepositorio
    {
        private readonly CampeonatosFifaContext context;
        public EstadioRepositorio(CampeonatosFifaContext context)
        {
            this.context = context;
        }

        public async Task<Estadio> Agregar(Estadio Estadio)
        {
            context.Estadios.Add(Estadio);
            await context.SaveChangesAsync();
            return Estadio;
        }

        public async Task<IEnumerable<Estadio>> Buscar(int Tipo, string Dato)
        {
            return await context.Estadios
                .Where(item => (Tipo == 0 && item.Nombre.Contains(Dato))
                || (Tipo == 1 && item.Ciudad.Nombre.Contains(Dato))
                || (Tipo == 2 && item.Ciudad.Pais.Nombre.Contains(Dato)))
                .Include(e => e.Ciudad)   // Incluir el objeto Ciudad
                    .ThenInclude(c => c.Pais) // Incluir el País de la Ciudad
                .ToArrayAsync();
        }

        public async Task<bool> Eliminar(int Id)
        {
            var EstadioExistente = await context.Estadios.FindAsync(Id);
            if (EstadioExistente == null)
            {
                return false;
            }
            try
            {
                context.Estadios.Remove(EstadioExistente);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Estadio> Modificar(Estadio Estadio)
        {
            var EstadioExistente = await context.Estadios.FindAsync(Estadio.Id);
            if (EstadioExistente == null)
            {
                return null;
            }

            context.Entry(EstadioExistente).CurrentValues.SetValues(Estadio);
            await context.SaveChangesAsync();

            return await context.Estadios.FindAsync(Estadio.Id);
        }

        public async Task<Estadio> Obtener(int Id)
        {
            return await context.Estadios.FindAsync(Id);
        }

        public async Task<IEnumerable<Estadio>> ObtenerTodos()
        {
            return await context.Estadios
                .Include(e => e.Ciudad)   // Incluir el objeto Ciudad
                    .ThenInclude(c => c.Pais) // Incluir el País de la Ciudad
                .ToArrayAsync();
        }
    }
}
