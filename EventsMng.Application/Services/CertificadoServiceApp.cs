using EventsMng.Application.Contracts.Dtos.Certificado;
using EventsMng.Infrastructure.Repositories;

public class CertificadoServiceApp : ICertificadoServiceApp
{
    private readonly IInscripcionRepository _inscripcionRepository;

    public CertificadoServiceApp(IInscripcionRepository inscripcionRepository)
    {
        _inscripcionRepository = inscripcionRepository;
    }

    public bool VerificarElegibilidad(VerificarElegibilidadDto dto)
    {
        var inscripcion = _inscripcionRepository
            .ObtenerInscripcion(dto.ParticipanteId, dto.EventoId);

        if (inscripcion == null)
            return false;

        // Ejemplo: debe estar aprobado y haber asistido
        return inscripcion.EstaAprobado && inscripcion.Asistencia >= 80;
    }
}