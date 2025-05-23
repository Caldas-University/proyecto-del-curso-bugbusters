using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsMng.Domain.Entities
{
    public class Participante
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nombre { get; set; } = string.Empty;

        public string Correo { get; set; } = string.Empty;

        public string DocumentoIdentidad { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        // Un Participante puede tener muchas Inscripciones
        public ICollection<Inscripcion>? Inscripciones { get; set; } 
    }
}
