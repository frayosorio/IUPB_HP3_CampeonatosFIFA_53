using CampeonatosFIFA.Dominio.DTOs;
using CampeonatosFIFA.Dominio.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CampeonatosFIFA.Infraestructura.Persistencia.Contexto
{
    public class CampeonatosFifaContext : DbContext
    {
        public CampeonatosFifaContext(DbContextOptions<CampeonatosFifaContext> options) : base(options)
        {
        }

        public DbSet<Seleccion> Selecciones { get; set; }
        public DbSet<Campeonato> Campeonatos { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Fase> Fases { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Estadio> Estadios { get; set; }
        public DbSet<Encuentro> Encuentros { get; set; }
        public DbSet<GrupoPais> GrupoPaises { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<TablaPosicionesDto> TablaPosiciones  { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.HasIndex(e => e.Nombre).IsUnique();
            });

            modelBuilder.Entity<Seleccion>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.HasIndex(e => e.Nombre).IsUnique();
            });

            modelBuilder.Entity<Campeonato>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.HasIndex(e => e.Nombre).IsUnique();
            });

            modelBuilder.Entity<Campeonato>()
                .HasOne(e => e.PaisOrganizador)
                .WithMany()
                .HasForeignKey(e => e.IdSeleccion);

            modelBuilder.Entity<Ciudad>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.HasIndex(e => new { e.IdSeleccion, e.Nombre }).IsUnique();
            });

            modelBuilder.Entity<Ciudad>()
               .HasOne(e => e.Pais)
               .WithMany()
               .HasForeignKey(e => e.IdSeleccion);

            modelBuilder.Entity<Estadio>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.HasIndex(e => e.Nombre).IsUnique();
            });

            modelBuilder.Entity<Estadio>()
                .HasOne(e => e.Ciudad)
                .WithMany()
                .HasForeignKey(e => e.IdCiudad);

            modelBuilder.Entity<Grupo>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.HasIndex(e => new { e.IdCampeonato, e.Nombre }).IsUnique();
            });

            modelBuilder.Entity<Grupo>()
                .HasOne(e => e.Campeonato)
                .WithMany()
                .HasForeignKey(e => e.IdCampeonato);

            modelBuilder.Entity<GrupoPais>(entidad =>
            {
                entidad.HasKey(e => new { e.IdGrupo, e.IdSeleccion });
            });

            modelBuilder.Entity<GrupoPais>()
               .HasOne(e => e.Grupo)
               .WithMany()
               .HasForeignKey(e => e.IdGrupo);

            modelBuilder.Entity<GrupoPais>()
                   .HasOne(e => e.Seleccion)
                   .WithMany()
                   .HasForeignKey(e => e.IdSeleccion);

            modelBuilder.Entity<Encuentro>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.HasIndex(e => new { e.IdCampeonato, e.IdFase, e.IdPais1, e.IdPais2 }).IsUnique();
            });

            modelBuilder.Entity<Encuentro>()
                .HasOne(e => e.Pais1)
                .WithMany()
                .HasForeignKey(e => e.IdPais1);

            modelBuilder.Entity<Encuentro>()
                .HasOne(e => e.Pais2)
                .WithMany()
                .HasForeignKey(e => e.IdPais2);

            modelBuilder.Entity<Encuentro>()
                .HasOne(e => e.Fase)
                .WithMany()
                .HasForeignKey(e => e.IdFase);

            modelBuilder.Entity<Encuentro>()
                .HasOne(e => e.Campeonato)
                .WithMany()
                .HasForeignKey(e => e.IdCampeonato);

            modelBuilder.Entity<Encuentro>()
                .HasOne(e => e.Estadio)
                .WithMany()
                .HasForeignKey(e => e.IdEstadio);

            //DTOs
            modelBuilder.Entity<TablaPosicionesDto>()
                .HasNoKey();


        }

        //***** Tabla de Posiciones *****

        public async Task<IEnumerable<TablaPosicionesDto>> ObtenerTablaPosicionesGrupo(int IdGrupo)
        {
            return await Set<TablaPosicionesDto>()
                .FromSqlRaw("SELECT * FROM fTablaPosicionesGrupo(@IdGrupo) ORDER BY Puntos DESC",
                new SqlParameter("@IdGrupo", IdGrupo))
                .ToListAsync();
                
        }
    }
}
