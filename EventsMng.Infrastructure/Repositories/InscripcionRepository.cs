using EventsMng.Domain.Entities;
using EventsMng.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
                .Include(i => i.Evento)
                .ToListAsync();
        }

        public async Task<List<Inscripcion>> ObtenerTodos()
        {
            return await _context.Inscripciones.ToListAsync();
        }

        public Task InscribirAsync(Guid eventoId, Guid participanteId)
        {
            throw new NotImplementedException();
        }

        public Task ObtenerPorEventoAsync(Guid eventoId)
        {
            throw new NotImplementedException();
        }

        public async Task<Inscripcion?> ObtenerPorIdAsync(Guid inscripcionId)
        {
            return await _context.Inscripciones.FindAsync(inscripcionId);
        }

        public async Task GuardarCambiosAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Inscripcion?> ObtenerPorIdConEventoAsync(Guid inscripcionId)
        {
            return await _context.Inscripciones
                .Include(i => i.Evento)
                .FirstOrDefaultAsync(i => i.Id == inscripcionId);
        }

        public Inscripcion ObtenerInscripcion(Guid participanteId, Guid eventoId)
        {
            return _context.Inscripciones
                .FirstOrDefault(i => i.ParticipanteId == participanteId && i.EventoId == eventoId);
        }


    }
}
