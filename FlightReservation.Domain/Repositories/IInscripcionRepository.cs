using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservation.Domain.Repositories
{
    public interface IInscripcionRepository
    {
        Task InscribirAsync(Guid eventoId, Guid participanteId);
        Task ObtenerPorEventoAsync(Guid eventoId);
    }
}
