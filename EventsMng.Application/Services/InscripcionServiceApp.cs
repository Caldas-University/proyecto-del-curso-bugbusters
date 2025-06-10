using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
