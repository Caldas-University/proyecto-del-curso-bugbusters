using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsMng.Domain.Entities
{
    public class Certificado
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid EventoId { get; set; }

        public Guid ParticipanteId { get; set; }

        public string CodigoVerificacion { get; set; } = string.Empty;

        public string UrlPdf { get; set; } = string.Empty;

        public DateTime FechaGeneracion { get; set; } = DateTime.UtcNow;

        // Propiedades de navegación (opcional)
        public Evento? Evento { get; set; }
    }
}
