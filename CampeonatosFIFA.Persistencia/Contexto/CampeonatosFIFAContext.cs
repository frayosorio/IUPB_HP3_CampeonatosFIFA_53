using CampeonatosFifa.Dominio.Entidades;
using CampeonatosFIFA.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CampeonatosFIFA.Persistencia.Contexto
{
    public class CampeonatosFIFAContext : DbContext
    {

        public CampeonatosFIFAContext(DbContextOptions<CampeonatosFIFAContext> options)
            : base(options)
        {

        }

        public DbSet<Seleccion> Selecciones { get; set; }
        public DbSet<Campeonato> Campeonatos { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Estadio> Estadios { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<GrupoPais> GruposPais { get; set; }
        public DbSet<Fase> Fases { get; set; }
        public DbSet<Encuentro> Encuentros { get; set; }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Seleccion>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.HasIndex(e => e.Nombre).IsUnique();
            });

            builder.Entity<Campeonato>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.HasIndex(e => e.Nombre).IsUnique();
            });

            builder.Entity<Campeonato>()
                .HasOne(e => e.PaisOrganizador)
                .WithMany()
                .HasForeignKey(e => e.IdSeleccion);

            builder.Entity<Grupo>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.HasIndex(e => new { e.IdCampeonato, e.Nombre }).IsUnique();
                entidad.HasOne<Campeonato>()
                   .WithMany()
                   .HasForeignKey(e => e.IdCampeonato);
            });

            builder.Entity<GrupoPais>(entidad =>
            {
                entidad.HasKey(e => new { e.IdGrupo, e.IdSeleccion });
            });

            builder.Entity<GrupoPais>()
                .HasOne(e => e.Grupo)
                .WithMany()
                .HasForeignKey(e => e.IdGrupo);

            builder.Entity<GrupoPais>()
                .HasOne(e => e.Seleccion)
                .WithMany()
                .HasForeignKey(e => e.IdSeleccion);

            builder.Entity<Fase>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.HasIndex(e => e.Nombre).IsUnique();
            });

            builder.Entity<Ciudad>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.HasIndex(e => new { e.IdSeleccion, e.Nombre }).IsUnique();
                entidad.HasOne<Seleccion>()
                   .WithMany()
                   .HasForeignKey(e => e.IdSeleccion);
            });

            builder.Entity<Estadio>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.HasIndex(e => e.Nombre).IsUnique();
                entidad.HasOne<Ciudad>()
                   .WithMany()
                   .HasForeignKey(e => e.IdCiudad);
            });

            builder.Entity<Encuentro>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.HasIndex(e => new { e.IdCampeonato, e.IdFase, e.IdPais1, e.IdPais2 }).IsUnique();
                entidad.HasOne<Seleccion>()
                   .WithMany()
                   .HasForeignKey(e => e.IdPais1);
                entidad.HasOne<Seleccion>()
                   .WithMany()
                   .HasForeignKey(e => e.IdPais2);
                entidad.HasOne<Fase>()
                   .WithMany()
                   .HasForeignKey(e => e.IdFase);
                entidad.HasOne<Campeonato>()
                   .WithMany()
                   .HasForeignKey(e => e.IdCampeonato);
                entidad.HasOne<Estadio>()
                   .WithMany()
                   .HasForeignKey(e => e.IdEstadio);
            });
        }



    }
}
