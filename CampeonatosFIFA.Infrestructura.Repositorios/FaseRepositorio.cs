using CampeonatosFIFA.Core.Repositorios;
using CampeonatosFIFA.Dominio.Entidades;
using CampeonatosFIFA.Infraestructura.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;

namespace CampeonatosFIFA.Infraestructura.Repositorios
{
    public class FaseRepositorio : IFaseRepositorio
    {
        private readonly CampeonatosFifaContext context;

        public FaseRepositorio(CampeonatosFifaContext context)
        {
            this.context = context;
        }


        public async Task<Fase> Agregar(Fase Fase)
        {
            context.Fases.Add(Fase);
            await context.SaveChangesAsync();
            return Fase;
        }

        public async Task<IEnumerable<Fase>> Buscar(int Tipo, string Dato)
        {
            return await context.Fases
                .Where(item => (Tipo == 0 && item.Nombre.Contains(Dato)))
                .ToArrayAsync();
        }

        public async Task<bool> Eliminar(int Id)
        {
            var FaseExistente = await context.Fases.FindAsync(Id);
            if (FaseExistente == null)
            {
                return false;
            }
            try
            {
                context.Fases.Remove(FaseExistente);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Fase> Modificar(Fase Fase)
        {
            var FaseExistente = await context.Fases.FindAsync(Fase.Id);
            if (FaseExistente == null)
            {
                return null;
            }

            context.Entry(FaseExistente).CurrentValues.SetValues(Fase);
            await context.SaveChangesAsync();

            return await context.Fases.FindAsync(Fase.Id);
        }

        public async Task<Fase> Obtener(int Id)
        {
            return await context.Fases.FindAsync(Id);
        }

        public async Task<IEnumerable<Fase>> ObtenerTodos()
        {
            return await context.Fases.ToArrayAsync();
        }
    }
}
