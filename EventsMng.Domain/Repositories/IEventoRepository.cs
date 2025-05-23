using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsMng.Domain.Repositories
{
    public interface IEventoRepository
    {
        Task ObtenerTodosAsync();
        Task ObtenerPorIdAsync(Guid id);
        Task CrearAsync(Guid id); // parámetro ficticio para compilar
    }
}

