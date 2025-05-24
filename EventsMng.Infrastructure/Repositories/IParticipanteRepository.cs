using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsMng.Infrastructure.Repositories
{
    public interface IParticipanteRepository
    {
        Task ObtenerTodosAsync();
        Task ObtenerPorIdAsync(Guid id);
        Task CrearAsync(Guid id); // para compilar
    }
}