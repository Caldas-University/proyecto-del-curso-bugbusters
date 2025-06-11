using EventsMng.Domain.Entities;

namespace EventsMng.Domain.Repositories
{
    public interface IInscripcionRepository
    {
        Task AgregarAsync(Inscripcion inscripcion);
        Task<Inscripcion?> ObtenerPorIdAsync(Guid id);
        Task<List<Inscripcion>> ObtenerPorEventoAsync(Guid eventoId);
        Task GuardarCambiosAsync();
    }
}
