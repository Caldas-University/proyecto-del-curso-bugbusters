using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsMng.Domain.Repositories
{
    public interface IListaEsperaRepository
    {
        Task AgregarAsync(Guid eventoId, Guid participanteId);
        Task ObtenerPorEventoAsync(Guid eventoId);
    }
}