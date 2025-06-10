using EventsMng.Application.Contracts.Services;
using EventsMng.Domain.Entities;
using EventsMng.Domain.Repositories;

public class EventoServiceApp : IEventoServiceApp
{
    private readonly IEventoRepository _eventoRepository;

    public EventoServiceApp(IEventoRepository eventoRepository)
    {
        _eventoRepository = eventoRepository;
    }

    public async Task<IEnumerable<Evento>> ObtenerTodosAsync()
    {
        return await _eventoRepository.ObtenerTodosAsync();
    }

    public async Task<Evento> ObtenerPorIdAsync(Guid id)
    {
        return await _eventoRepository.ObtenerPorIdAsync(id);
    }

    public async Task CrearAsync(Evento evento)
    {
        await _eventoRepository.CrearAsync(evento);
    }

    public async Task LiberarCupoAsync(Guid eventoId, Guid inscripcionId)
    {
        var evento = await _eventoRepository.ObtenerPorIdAsync(eventoId);
        if (evento == null)
            throw new InvalidOperationException("Evento no encontrado.");

        evento.CancelarInscripcion(inscripcionId);
        await _eventoRepository.ActualizarAsync(evento);
    }
}
