using FlightReservation.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservation.Infrastructure.Repositories
{
    public class ParticipanteRepository : IParticipanteRepository
    {
        public Task ObtenerTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task ObtenerPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task CrearAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}