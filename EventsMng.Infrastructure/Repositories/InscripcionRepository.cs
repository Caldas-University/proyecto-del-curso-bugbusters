using EventsMng.Domain.Entities;
using EventsMng.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EventsMng.Infrastructure.Persistence
{
    public class InscripcionRepository : IInscripcionRepository
    {
        private readonly ApplicationDbContext _context;

        public InscripcionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> ContarConfirmadasPorEventoAsync(Guid eventoId)
        {
            return await _context.Inscripciones
                .CountAsync(i => i.EventoId == eventoId && i.Estado == InscripcionEstado.Confirmada);
        }

        public async Task AgregarAsync(Inscripcion inscripcion)
        {
            _context.Inscripciones.Add(inscripcion);
            await _context.SaveChangesAsync();
        }

        public async Task<Inscripcion?> ObtenerAsync(Guid eventoId, Guid participanteId)
        {
            return await _context.Inscripciones
                .FirstOrDefaultAsync(i => i.EventoId == eventoId && i.ParticipanteId == participanteId);
        }

        public async Task GuardarCambiosAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

