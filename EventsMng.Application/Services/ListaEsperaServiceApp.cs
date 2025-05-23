using System;
using EventsMng.Application.Contracts.Services;
using EventsMng.Domain.Entities;
using System;

namespace EventsMng.Application.Services
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

