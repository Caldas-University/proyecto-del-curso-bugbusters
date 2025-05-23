using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsMng.Domain.Entities;

namespace EventsMng.Application.Contracts.Services
{
    public interface IEventoServiceApp
    {
        Task ObtenerTodosAsync();
        Task ObtenerPorIdAsync(Guid id);
        Task CrearAsync(Guid eventoId);
    }
}
