using EventsMng.Domain.Entities;
using EventsMng.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EventsMng.Infrastructure.Persistence.Repositories
{
    public class InscripcionRepository : IInscripcionRepository
    {
        private readonly ApplicationDbContext _context;

        public InscripcionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AgregarAsync(Inscripcion inscripcion)
        {
            await _context.Inscripciones.AddAsync(inscripcion);
        }

        public async Task<Inscripcion?> ObtenerPorIdAsync(Guid id)
        {
            return await _context.Inscripciones
                .Include(i => i.Evento)
                .Include(i => i.Participante)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Inscripcion>> ObtenerPorEventoAsync(Guid eventoId)
        {
            return await _context.Inscripciones
                .Where(i => i.EventoId == eventoId)
                .ToListAsync();
        }

        public async Task GuardarCambiosAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
