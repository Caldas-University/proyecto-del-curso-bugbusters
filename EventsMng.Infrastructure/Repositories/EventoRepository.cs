using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsMng.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventsMng.Infrastructure.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        public Task ObtenerTodosAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Evento?> ObtenerPorIdAsync(Guid id)
        {
            return await _context.Eventos
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public Task CrearAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
