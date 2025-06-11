namespace EventsMng.Application.Contracts.Dtos.Inscripcion
{
    public class HistorialParticipacionDto
    {
        public int EventoId { get; set; }
        public string NombreEvento { get; set; }
        public DateTime FechaEvento { get; set; }
        public string Estado { get; set; }
        public bool CertificadoEmitido { get; set; }
    }
}
