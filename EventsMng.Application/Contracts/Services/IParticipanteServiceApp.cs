using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightReservation.Domain.Entities;

namespace FlightReservation.Application.Contracts.Services
{
    public interface IParticipanteServiceApp
    {
        Task ObtenerTodosAsync();
        Task ObtenerPorIdAsync(Guid id);
        Task CrearAsync(Guid id); // parámetro ficticio para que compile
    }
}
  }
}

