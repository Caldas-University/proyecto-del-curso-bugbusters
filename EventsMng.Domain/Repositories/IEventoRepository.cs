using EventsMng.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsMng.Domain.Repositories
{
    public interface IEventoRepository
    {
        Task<IEnumerable<Evento>> ObtenerTodosAsync();
        Task<Evento?> ObtenerPorIdAsync(Guid id);

        Task CrearAsync(Guid id); // parámetro ficticio para compilar
    }
}

