using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsMng.Application.Contracts.Services;

namespace EventsMng.Application.Services
{
    public class CertificadoServiceApp : ICertificadoServiceApp
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

