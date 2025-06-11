using EventsMng.Application.Contracts.Services;
using EventsMng.Domain.Entities;
using EventsMng.Domain.Repositories;

namespace EventsMng.Application.Services
{
    public class InscripcionServiceApp : IInscripcionServiceApp
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IInscripcionRepository _inscripcionRepository;
        private readonly IListaEsperaRepository _listaEsperaRepository;

        public InscripcionServiceApp(
            IEventoRepository eventoRepository,
            IInscripcionRepository inscripcionRepository,
            IListaEsperaRepository listaEsperaRepository)
        {
            _eventoRepository = eventoRepository;
            _inscripcionRepository = inscripcionRepository;
            _listaEsperaRepository = listaEsperaRepository;
        }

        public async Task InscribirAsync(Guid eventoId, Guid participanteId)
        {
            var evento = await _eventoRepository.ObtenerPorIdAsync(eventoId);
            if (evento == null)
                throw new InvalidOperationException("Evento no encontrado");

            var inscritos = await _inscripcionRepository.ContarConfirmadasPorEventoAsync(eventoId);

            var estado = inscritos < evento.CupoMaximo
                ? InscripcionEstado.Confirmada
                : InscripcionEstado.Cancelada;

            var inscripcion = new Inscripcion
            {
                EventoId = eventoId,
                ParticipanteId = participanteId,
                Estado = estado,
                FechaInscripcion = DateTime.UtcNow
            };

            await _inscripcionRepository.AgregarAsync(inscripcion);

            if (estado == InscripcionEstado.Cancelada)
            {
                var lista = new ListaEspera
                {
                    EventoId = eventoId,
                    ParticipanteId = participanteId,
                    FechaRegistro = DateTime.UtcNow
                };
                await _listaEsperaRepository.AgregarAsync(lista);
            }
        }

        public async Task CancelarAsync(Guid eventoId, Guid participanteId)
        {
            var inscripcion = await _inscripcionRepository.ObtenerAsync(eventoId, participanteId);
            if (inscripcion == null)
                throw new InvalidOperationException("Inscripción no encontrada");

            inscripcion.Cancelar();
            await _inscripcionRepository.GuardarCambiosAsync();
        }

        public async Task RegistrarAsistenciaAsync(Guid eventoId, Guid participanteId)
        {
            var inscripcion = await _inscripcionRepository.ObtenerAsync(eventoId, participanteId);
            if (inscripcion == null)
                throw new InvalidOperationException("Inscripción no encontrada");

            inscripcion.RegistrarAsistencia();
            await _inscripcionRepository.GuardarCambiosAsync();
        }
        public async Task<IEnumerable<Inscripcion>> ObtenerPorEventoAsync(Guid eventoId)
        {
            return await _inscripcionRepository.ObtenerPorEventoAsync(eventoId);
        }

    }
}



