using EventsMng.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsMng.Infrastructure.Repositories
{
    public class ListaEsperaRepository : IListaEsperaRepository
    {
        public Task AgregarAsync(Guid eventoId, Guid participanteId)
        {
            throw new NotImplementedException();
        }

        public Task ObtenerPorEventoAsync(Guid eventoId)
        {
            throw new NotImplementedException();
        }
    }
}
