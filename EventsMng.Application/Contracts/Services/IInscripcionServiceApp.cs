using EventsMng.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsMng.Application.Contracts.Services
{
    public interface IInscripcionServiceApp
    {
        Task<List<Inscripcion>> ObtenerHistorialPorParticipanteAsync(Guid participanteId);
        Task InscribirAsync(Guid eventoId, Guid participanteId);
    }
}
