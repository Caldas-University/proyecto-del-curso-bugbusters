using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EventsMng.Application.Contracts.Services
{
    public interface ICertificadoServiceApp
    {
        Task ObtenerPorCodigoAsync(string codigo);
        Task GenerarAsync(string codigo); // parámetro ficticio
    }
}


