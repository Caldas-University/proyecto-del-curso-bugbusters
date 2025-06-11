using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsMng.Application.Contracts.Dtos.Certificado;


namespace EventsMng.Application.Contracts.Services
{
    public interface ICertificadoServiceApp
    {
        Task ObtenerPorCodigoAsync(string codigo);
        Task GenerarAsync(string codigo); // parámetro ficticio
        bool VerificarElegibilidad(VerificarElegibilidadDto dto);
    }
}


