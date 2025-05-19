using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightReservation.Application.Contracts.Services;

namespace FlightReservation.Application.Services
{
    public class InscripcionServiceApp : IInscripcionServiceApp
    {
        public Task InscribirAsync(Guid eventoId, Guid participanteId)
        {
            throw new NotImplementedException();
        }
    }
}
