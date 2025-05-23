using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EventsMng.Application.Contracts.Services;


namespace EventsMng.Application.Services
{
    public class ParticipanteServiceApp : IParticipanteServiceApp
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


