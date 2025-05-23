using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsMng.Application.Contracts.Services
{
    public interface IListaEsperaServiceApp
    {
        Task AgregarAsync(Guid eventoId, Guid participanteId);
        Task ObtenerPorEventoAsync(Guid eventoId);
    }
}


