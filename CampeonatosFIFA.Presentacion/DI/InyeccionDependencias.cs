using CampeonatosFIFA.aplicacion;
using CampeonatosFIFA.Core.Repositorios;
using CampeonatosFIFA.Core.Servicios;
using CampeonatosFIFA.Infraestructura.Repositorios;
using CampeonatosFIFA.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;

namespace CampeonatosFIFA.Presentacion.DI
{
    public static class InyeccionDependencias
    {

        public static IServiceCollection AgregarDependencias(this IServiceCollection servicios,
                                                            IConfiguration configuracion)
        {
            //agregar la instancia del DbContext
            servicios.AddDbContext<CampeonatosFIFAContext>(opciones =>
            {
                opciones.UseSqlServer(configuracion.GetConnectionString("CampeonatosFIFA"));
            });

            //agregar repositorios
            servicios.AddTransient<ISeleccionRepositorio, SeleccionRepositorio>();

            //agregar servicios
            servicios.AddTransient<ISeleccionServicio, SeleccionServicio>();



            return servicios;
        }
    }
}
