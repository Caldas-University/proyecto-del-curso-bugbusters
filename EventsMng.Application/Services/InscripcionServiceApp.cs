using EventsMng.Application.Contracts.Services;
using EventsMng.Domain.Entities;
using EventsMng.Domain.Repositories;

namespace EventsMng.Application.Services
{
    public class InscripcionServiceApp : IInscripcionServiceApp
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IInscripcionRepository _inscripcionRepository;

        public InscripcionServiceApp(IEventoRepository eventoRepository, IInscripcionRepository inscripcionRepository)
        {
            _eventoRepository = eventoRepository;
            _inscripcionRepository = inscripcionRepository;
        }

        public async Task InscribirAsync(Guid eventoId, Guid participanteId)
        {
            var evento = await _eventoRepository.ObtenerPorIdAsync(eventoId)
                ?? throw new InvalidOperationException("Evento no encontrado.");

            if (evento.CuposDisponibles <= 0)
                throw new InvalidOperationException("No hay cupos disponibles.");

            // Crear la inscripción
            var inscripcion = new Inscripcion
            {
                EventoId = eventoId,
                ParticipanteId = participanteId,
                FechaInscripcion = DateTime.UtcNow,
                Estado = InscripcionEstado.Confirmada
            };

            // Relacionarla con el evento
            evento.Inscripciones ??= new List<Inscripcion>();
            evento.Inscripciones.Add(inscripcion);

            // Guardar cambios
            await _inscripcionRepository.AgregarAsync(inscripcion);
            await _eventoRepository.ActualizarAsync(evento); // Solo si hace falta
        }
    }
}
