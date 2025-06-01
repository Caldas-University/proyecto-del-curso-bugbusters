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
    public class InscripcionServiceApp(IInscripcionRepository inscripcionRepo) : IInscripcionServiceApp
    {
        private readonly IInscripcionRepository _inscripcionRepo = inscripcionRepo;

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

            if (inscripcion == null || inscripcion.ParticipanteId != participanteId)
                return false;

            if (inscripcion.Evento == null || !inscripcion.Evento.PuedeCancelar())
                return false;

            inscripcion.Estado = InscripcionEstado.Cancelada;
            await _inscripcionRepo.GuardarCambiosAsync();
            return true;
        }

    }
}
