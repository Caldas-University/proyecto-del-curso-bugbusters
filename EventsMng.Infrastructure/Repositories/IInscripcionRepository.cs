using EventsMng.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsMng.Infrastructure.Repositories
{
    public interface IInscripcionRepository
    {
        Task InscribirAsync(Guid eventoId, Guid participanteId);
        Task<List<Inscripcion>> ObtenerTodos();
        Task ObtenerPorEventoAsync(Guid eventoId);
        Task<List<Inscripcion>> ObtenerPorParticipanteAsync(Guid participanteId);
        Task<Inscripcion?> ObtenerPorIdAsync(Guid inscripcionId);
        Task GuardarCambiosAsync();
        Task<Inscripcion?> ObtenerPorIdConEventoAsync(Guid inscripcionId);

    }
}
