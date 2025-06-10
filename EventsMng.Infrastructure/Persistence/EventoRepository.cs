using EventsMng.Domain.Entities;
using EventsMng.Domain.Repositories;
using EventsMng.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EventsMng.Infrastructure.Persistence
{
    public class EventoRepository : IEventoRepository
    {
        private readonly ApplicationDbContext _context;
        public EventoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Evento>> ObtenerTodosAsync()
        {
            return await _context.Eventos
                .Include(e => e.Inscripciones)
                .ToListAsync();
        }

        public async Task<Evento?> ObtenerPorIdAsync(Guid id)
        {
            return await _context.Eventos
                .Include(e => e.Inscripciones)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task CrearAsync(Evento evento)
        {
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();
        }
        public async Task ActualizarAsync(Evento evento)
        {
            _context.Eventos.Update(evento);
            await _context.SaveChangesAsync();
        }
    }
}
