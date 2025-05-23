using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsMng.Domain.Repositories
{
    public interface ICertificadoRepository
    {
        Task ObtenerPorCodigoAsync(string codigo);
        Task GenerarAsync(string codigo); // parámetro para compilar
    }
}
