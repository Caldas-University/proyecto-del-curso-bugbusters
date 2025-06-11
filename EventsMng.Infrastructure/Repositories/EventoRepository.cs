using EventsMng.Domain.Entities;
using EventsMng.Domain.Repositories;
using EventsMng.Infrastructure.Persistence; // Asegúrate de importar esto
using Microsoft.EntityFrameworkCore;

namespace EventsMng.Domain.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly ApplicationDbContext _context;

        public EventoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Evento>> ObtenerTodosAsync()
        {
            return await _context.Eventos.ToListAsync();
        }

        public async Task<Evento?> ObtenerPorIdAsync(Guid id)
        {
            return await _context.Eventos.FindAsync(id);
        }

        public Task CrearAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

