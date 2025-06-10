using EventsMng.Domain.Entities;
using EventsMng.Domain.Repositories;
using EventsMng.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class CertificadoRepository(ApplicationDbContext context) : ICertificadoRepository
{
    private readonly ApplicationDbContext _context = context;

    public Task<Certificado?> ObtenerPorCodigoAsync(string codigo)
    {
        throw new NotImplementedException();
    }

    public Task GenerarAsync(string codigo)
    {
        throw new NotImplementedException();
    }

    public async Task<Certificado?> ObtenerPorEventoYParticipanteAsync(Guid eventoId, Guid participanteId)
    {
        return await _context.Certificados
            .FirstOrDefaultAsync(c => c.EventoId == eventoId && c.ParticipanteId == participanteId);
    }
}
