using EventsMng.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsMng.Infrastructure.Repositories
{
    public interface IListaEsperaRepository
    {
        Task AgregarAsync(Guid eventoId, Guid participanteId);
        Task<List<ListaEspera>> ObtenerPorEventoAsync(Guid eventoId);
        Task<bool> YaEstaEnLista(Guid eventoId, Guid participanteId);
    }
}