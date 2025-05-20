using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightReservation.Application.Contracts.Services;
using FlightReservation.Domain.Entities;

namespace FlightReservation.Application.Services
{
    public class EventoServiceApp : IEventoServiceApp
    {
        public Task ObtenerTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task ObtenerPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task CrearAsync(Guid eventoId)
        {
            throw new NotImplementedException();
        }
    }
}



