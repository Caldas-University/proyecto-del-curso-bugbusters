using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsMng.Domain.Entities
{
    public class Evento
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nombre { get; set; } = string.Empty;

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public int CupoMaximo { get; set; }

        public bool OfreceCertificado { get; set; }

        // Un evento puede tener varios certificados
        public ICollection<Certificado>? Certificados { get; set; }

        public ICollection<Inscripcion>? Inscripciones { get; set; }

    }
}