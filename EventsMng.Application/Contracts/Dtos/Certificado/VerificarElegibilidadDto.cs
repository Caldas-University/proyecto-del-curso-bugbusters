namespace EventsMng.Application.Contracts.Dtos.Certificado
{
    public class VerificarElegibilidadDto
    {
        public Guid ParticipanteId { get; set; }
        public Guid EventoId { get; set; }
    }
}
