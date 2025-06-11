using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsMng.Infrastructure.Repositories;
using EventsMng.Domain.Entities;

namespace EventsMng.Infrastructure.Repositories
{
    public interface ICertificadoRepository
    {
        Task<Certificado?> ObtenerPorCodigoAsync(string codigo);
        public async Task GenerarAsync(string codigo)
        {
            throw new NotImplementedException();
        }
        Task<Certificado?> ObtenerPorEventoYParticipanteAsync(Guid eventoId, Guid participanteId);
    }
}
