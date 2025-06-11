using EventsMng.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsMng.Infrastructure.Persistence
{
    public class CertificadoRepository : ICertificadoRepository
    {
        public Task ObtenerPorCodigoAsync(string codigo)
        {
            throw new NotImplementedException();
        }

        public Task GenerarAsync(string codigo)
        {
            throw new NotImplementedException();
        }
    }
}
