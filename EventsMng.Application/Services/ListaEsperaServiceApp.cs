using System;
using FlightReservation.Application.Contracts.Services;
using FlightReservation.Domain.Entities;
using System;

namespace FlightReservation.Application.Services
{
    public class ListaEsperaServiceApp : IListaEsperaServiceApp
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

