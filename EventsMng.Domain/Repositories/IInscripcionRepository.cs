using EventsMng.Domain.Entities;

namespace EventsMng.Domain.Repositories
{
    public interface IInscripcionRepository
    {
        Task<int> ContarConfirmadasPorEventoAsync(Guid eventoId);
        Task AgregarAsync(Inscripcion inscripcion);
        Task<Inscripcion?> ObtenerAsync(Guid eventoId, Guid participanteId);
        Task GuardarCambiosAsync();
    }
}

