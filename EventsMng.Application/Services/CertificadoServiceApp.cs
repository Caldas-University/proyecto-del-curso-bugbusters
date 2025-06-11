using EventsMng.Application.Contracts.Dtos.Certificado;
using EventsMng.Infrastructure.Repositories;
using EventsMng.Application.Contracts.Services;
using System.Threading.Tasks;
using EventsMng.Domain.Entities;
using System;
namespace EventsMng.Application.Services;


public class CertificadoServiceApp : ICertificadoServiceApp
{
    private readonly IInscripcionRepository _inscripcionRepository;
    private readonly ICertificadoRepository _certificadoRepository;

    public CertificadoServiceApp(
        IInscripcionRepository inscripcionRepository,
        ICertificadoRepository certificadoRepository) 
    {
        _inscripcionRepository = inscripcionRepository;
        _certificadoRepository = certificadoRepository;
    }

    public bool VerificarElegibilidad(VerificarElegibilidadDto dto)
    {
        var inscripcion = _inscripcionRepository
            .ObtenerInscripcion(dto.ParticipanteId, dto.EventoId);

        if (inscripcion == null)
            return false;

        return inscripcion.Estado == InscripcionEstado.Asistio;
    }

    public async Task GenerarAsync(string codigo)
    {
        await Task.CompletedTask;
    }

    public async Task ObtenerPorCodigoAsync(string codigo)
    {
        await Task.CompletedTask;
    }

    public async Task<Certificado?> ObtenerPorEventoYParticipanteAsync(Guid eventoId, Guid participanteId)
    {
        return await _certificadoRepository.ObtenerPorEventoYParticipanteAsync(eventoId, participanteId);
    }
}