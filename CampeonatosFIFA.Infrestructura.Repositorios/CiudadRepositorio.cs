using CampeonatosFIFA.Core.Repositorios;
using CampeonatosFIFA.Dominio.Entidades;
using CampeonatosFIFA.Infraestructura.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;

namespace CampeonatosFIFA.Infraestructura.Repositorios
{
    public class CiudadRepositorio : ICiudadRepositorio
    {
        private readonly CampeonatosFifaContext context;
        public CiudadRepositorio(CampeonatosFifaContext context)
        {
            this.context = context;
        }

        public async Task<Ciudad> Agregar(Ciudad Ciudad)
        {
            context.Ciudades.Add(Ciudad);
            await context.SaveChangesAsync();
            return Ciudad;
        }

        public async Task<IEnumerable<Ciudad>> Buscar(int Tipo, string Dato)
        {
            return await context.Ciudades
                .Where(item => (Tipo == 0 && item.Nombre.Contains(Dato))
                || (Tipo == 1 && item.Pais.Nombre.Contains(Dato)))
                .Include(e => e.Pais)   // Incluir el objeto Pais
                .ToArrayAsync();
        }

        public async Task<bool> Eliminar(int Id)
        {
            var CiudadExistente = await context.Ciudades.FindAsync(Id);
            if (CiudadExistente == null)
            {
                return false;
            }
            try
            {
                context.Ciudades.Remove(CiudadExistente);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Ciudad> Modificar(Ciudad Ciudad)
        {
            var CiudadExistente = await context.Ciudades.FindAsync(Ciudad.Id);
            if (CiudadExistente == null)
            {
                return null;
            }

            context.Entry(CiudadExistente).CurrentValues.SetValues(Ciudad);
            await context.SaveChangesAsync();

            return await context.Ciudades.FindAsync(Ciudad.Id);
        }

        public async Task<Ciudad> Obtener(int Id)
        {
            return await context.Ciudades.FindAsync(Id);
        }

        public async Task<IEnumerable<Ciudad>> ObtenerTodos()
        {
            return await context.Ciudades
                .Include(e => e.Pais)   // Incluir el objeto Pais
                .ToArrayAsync();
        }
    }
}
