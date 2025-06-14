using Microsoft.EntityFrameworkCore;
using EventsMng.Domain.Entities;

namespace EventsMng.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Certificado> Certificados { get; set; }
        public DbSet<ListaEspera> ListasEspera { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Inscripcion>()
                .HasOne(i => i.Evento)
                .WithMany()
                .HasForeignKey(i => i.EventoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Inscripcion>()
                .HasOne(i => i.Participante)
                .WithMany()
                .HasForeignKey(i => i.ParticipanteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Certificado>()
                .HasOne(c => c.Evento)
                .WithMany(e => e.Certificados)
                .HasForeignKey(c => c.EventoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ListaEspera>()
                .HasOne(le => le.Evento)
                .WithMany()
                .HasForeignKey(le => le.EventoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
