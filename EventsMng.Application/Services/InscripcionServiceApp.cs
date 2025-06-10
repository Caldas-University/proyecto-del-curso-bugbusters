using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsMng.Application.Contracts.Dtos.Inscripcion;
using EventsMng.Application.Contracts.Services;
using EventsMng.Domain.Entities;
using EventsMng.Domain.Repositories;

namespace EventsMng.Application.Services
{
    public class InscripcionServiceApp(IInscripcionRepository inscripcionRepo,
    IEventoRepository eventoRepo,
    ICertificadoRepository certificadoRepo) : IInscripcionServiceApp
    {
        private readonly IInscripcionRepository _inscripcionRepo = inscripcionRepo;
        private readonly IEventoRepository _eventoRepo = eventoRepo;
        private readonly ICertificadoRepository _certificadoRepo = certificadoRepo;

        public async Task<List<Inscripcion>> ObtenerHistorialPorParticipanteAsync(Guid participanteId)
        {
            return await _inscripcionRepo.ObtenerPorParticipanteAsync(participanteId);
        }

        public Task InscribirAsync(Guid eventoId, Guid participanteId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Inscripcion>> ObtenerInscripcionesAsync()
        {
            return await _inscripcionRepo.ObtenerTodos();
        }

        public async Task<bool> ActualizarInscripcionAsync(Guid inscripcionId, ActualizarInscripcionDto dto)
        {
            var inscripcion = await _inscripcionRepo.ObtenerPorIdAsync(inscripcionId);
            if (inscripcion == null) return false;

            if (dto.ParticipanteId.HasValue)
                inscripcion.ParticipanteId = dto.ParticipanteId.Value;

            if (dto.Estado.HasValue)
                inscripcion.Estado = (InscripcionEstado)dto.Estado.Value;

            await _inscripcionRepo.GuardarCambiosAsync();
            return true;
        }

        public async Task<bool> CancelarInscripcionAsync(Guid inscripcionId, Guid participanteId)
        {
            var inscripcion = await _inscripcionRepo.ObtenerPorIdConEventoAsync(inscripcionId);

            // Validar existencia y que pertenezca al participante
            if (inscripcion == null || inscripcion.ParticipanteId != participanteId)
                return false;

            // Validar estado actual
            if (inscripcion.Estado == InscripcionEstado.Cancelada || inscripcion.Estado == InscripcionEstado.Asistio)
                return false;

            // Validar que el evento permita cancelación
            if (inscripcion.Evento == null || !inscripcion.Evento.PuedeCancelar())
                return false;

            // Cancelar inscripción
            inscripcion.Estado = InscripcionEstado.Cancelada;
            await _inscripcionRepo.GuardarCambiosAsync();
            return true;
        }

        public async Task<List<HistorialParticipacionDto>> ObtenerHistorialDetalladoAsync(Guid participanteId)
        {
            var inscripciones = await _inscripcionRepo.ObtenerPorParticipanteAsync(participanteId);
            var historial = new List<HistorialParticipacionDto>();

            foreach (var inscripcion in inscripciones)
            {
                var evento = await _eventoRepo.ObtenerPorIdAsync(inscripcion.EventoId);
                var certificado = await _certificadoRepo.ObtenerPorEventoYParticipanteAsync(inscripcion.EventoId, participanteId);

                historial.Add(new HistorialParticipacionDto
                {
                    EventoId = evento.Id,
                    NombreEvento = evento.Nombre,
                    FechaEvento = evento.Fecha,
                    Estado = inscripcion.Estado.ToString(),
                    Asistencia = inscripcion.Asistencia,
                    CertificadoEmitido = certificado != null
                });
            }

            return historial;
        }


    }
}
