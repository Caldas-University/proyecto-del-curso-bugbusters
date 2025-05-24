using EventsMng.Domain.Entities;
using EventsMng.Domain.Repositories;
using EventsMng.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsMng.Infrastructure.Repositories
{
    public class InscripcionRepository(ApplicationDbContext context) : IInscripcionRepository

    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<Inscripcion>> ObtenerPorParticipanteAsync(Guid participanteId)
        {
            return await _context.Inscripciones
                .Where(i => i.ParticipanteId == participanteId)
                .Include(i => i.Evento) // Para que puedas ver el nombre del evento, etc.
                .ToListAsync();
        }

        public Task InscribirAsync(Guid eventoId, Guid participanteId)
        {
            throw new NotImplementedException();
        }

        public Task ObtenerPorEventoAsync(Guid eventoId)
        {
            throw new NotImplementedException();
        }
    }
}
