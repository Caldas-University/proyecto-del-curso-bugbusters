using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsMng.Domain.Entities; 

namespace EventsMng.Infrastructure.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        public Task ObtenerTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Evento> ObtenerPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task CrearAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
