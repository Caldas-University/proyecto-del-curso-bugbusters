using Microsoft.AspNetCore.Mvc;
using EventsMng.Application.Contracts.Services;

[ApiController]
[Route("api/[controller]")]
public class InscripcionController : ControllerBase
{
    private readonly IInscripcionServiceApp _inscripcionService;

    public InscripcionController(IInscripcionServiceApp inscripcionService)
    {
        _inscripcionService = inscripcionService;
    }

    [HttpPost("inscribir")]
    public async Task<IActionResult> Inscribirse(Guid eventoId, Guid participanteId)
    {
        await _inscripcionService.InscribirAsync(eventoId, participanteId);
        return Ok("Inscripción procesada correctamente");
    }

    [HttpPost("cancelar")]
    public async Task<IActionResult> Cancelar(Guid eventoId, Guid participanteId)
    {
        await _inscripcionService.CancelarAsync(eventoId, participanteId);
        return Ok("Inscripción cancelada correctamente");
    }

    [HttpPost("asistencia")]
    public async Task<IActionResult> RegistrarAsistencia(Guid eventoId, Guid participanteId)
    {
        await _inscripcionService.RegistrarAsistenciaAsync(eventoId, participanteId);
        return Ok("Asistencia registrada correctamente");
    }
}


