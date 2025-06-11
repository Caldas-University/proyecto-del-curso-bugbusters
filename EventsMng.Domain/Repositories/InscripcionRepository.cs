using EventsMng.Domain.Entities;
using EventsMng.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsMng.Infrastructure.Repositories
{
    public class InscripcionRepository : IInscripcionRepository
    {
        public Task InscribirAsync(Guid eventoId, Guid participanteId)
        {
            throw new NotImplementedException();
        }

        public Task ObtenerPorEventoAsync(Guid eventoId)
        {
            throw new NotImplementedException();
        }

        Task IInscripcionRepository.AgregarAsync(Inscripcion inscripcion)
        {
            throw new NotImplementedException();
        }

        Task IInscripcionRepository.GuardarCambiosAsync()
        {
            throw new NotImplementedException();
        }

        Task<List<Inscripcion>> IInscripcionRepository.ObtenerPorEventoAsync(Guid eventoId)
        {
            throw new NotImplementedException();
        }

        Task<Inscripcion?> IInscripcionRepository.ObtenerPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
