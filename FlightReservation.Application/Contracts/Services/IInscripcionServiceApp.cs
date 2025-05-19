using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservation.Application.Contracts.Services
{
    public interface IInscripcionServiceApp
    {
        Task InscribirAsync(Guid eventoId, Guid participanteId);
    }
}
