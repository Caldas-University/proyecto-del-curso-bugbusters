using Microsoft.EntityFrameworkCore;
using FlightReservation.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using FlightReservation.Infrastructure.Persistence;

[ApiController]
[Route("api/[controller]")]
public class CertificadoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CertificadoController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("{codigo}")]
    public async Task<ActionResult<Certificado>> ObtenerPorCodigo(string codigo)
    {
        var cert = await _context.Certificados.FirstOrDefaultAsync(c => c.CodigoVerificacion == codigo);
        if (cert == null)
            return NotFound();

        return cert;
    }

    [HttpPost]
    public async Task<IActionResult> Generar(Certificado certificado)
    {
        _context.Certificados.Add(certificado);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(ObtenerPorCodigo), new { codigo = certificado.CodigoVerificacion }, certificado);
    }
}
