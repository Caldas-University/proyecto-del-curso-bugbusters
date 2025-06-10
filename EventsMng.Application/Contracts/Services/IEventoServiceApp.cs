using EventsMng.Domain.Entities;

namespace EventsMng.Application.Contracts.Services
{
    public interface IEventoServiceApp
    {
        Task<IEnumerable<Evento>> ObtenerTodosAsync();
        Task<Evento> ObtenerPorIdAsync(Guid id);
        Task CrearAsync(Evento evento);
        Task LiberarCupoAsync(Guid eventoId, Guid inscripcionId);
    }
}
