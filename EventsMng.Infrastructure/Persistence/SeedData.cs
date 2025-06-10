using EventsMng.Domain.Entities;

namespace EventsMng.Infrastructure.Persistence
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Asegúrate de que la base de datos esté creada
            context.Database.EnsureCreated();

            // Verifica si ya hay datos
            if (context.Participantes.Any() || context.Eventos.Any())
                return;

            // Participantes
            var participante1 = new Participante
            {
                Id = Guid.NewGuid(),
                Nombre = "Ana Pérez",
                Correo = "ana@example.com",
                DocumentoIdentidad = "123456789",
                Telefono = "555-1111"
            };

            var participante2 = new Participante
            {
                Id = Guid.NewGuid(),
                Nombre = "Carlos Gómez",
                Correo = "carlos@example.com",
                DocumentoIdentidad = "987654321",
                Telefono = "555-2222"
            };

            // Eventos
            var evento1 = new Evento
            {
                Id = Guid.NewGuid(),
                Nombre = "Conferencia .NET",
                FechaInicio = DateTime.Now.AddDays(7),
                FechaFin = DateTime.Now.AddDays(9),
                CupoMaximo = 100,
                OfreceCertificado = true
            };

            var evento2 = new Evento
            {
                Id = Guid.NewGuid(),
                Nombre = "Curso de C# Avanzado",
                FechaInicio = DateTime.Now.AddDays(10),
                FechaFin = DateTime.Now.AddDays(15),
                CupoMaximo = 50,
                OfreceCertificado = false
            };

            // Inscripciones
            var inscripcion1 = new Inscripcion
            {
                Id = Guid.NewGuid(),
                EventoId = evento1.Id,
                ParticipanteId = participante1.Id,
                FechaInscripcion = DateTime.Now,
                Estado = InscripcionEstado.Confirmada
            };

            var inscripcion2 = new Inscripcion
            {
                Id = Guid.NewGuid(),
                EventoId = evento2.Id,
                ParticipanteId = participante1.Id,
                FechaInscripcion = DateTime.Now,
                Estado = InscripcionEstado.Confirmada
            };

            var inscripcion3 = new Inscripcion
            {
                Id = Guid.NewGuid(),
                EventoId = evento2.Id,
                ParticipanteId = participante2.Id,
                FechaInscripcion = DateTime.Now,
                Estado = InscripcionEstado.Asistio
            };

            // Agrega todo al contexto
            context.Participantes.AddRange(participante1, participante2);
            context.Eventos.AddRange(evento1, evento2);
            context.Inscripciones.AddRange(inscripcion1, inscripcion2, inscripcion3);

            // Guarda cambios
            context.SaveChanges();
        }
    }
}
