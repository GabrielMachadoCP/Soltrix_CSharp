using System;

namespace Soltrix.Models
{
    public class EventoEnergia
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UsuarioCPF { get; set; }  // Adicionado
        public DateTime DataHora { get; set; }
        public bool EnergiaAtiva { get; set; }
        public string Motivo { get; set; }
        public string Fonte { get; set; }
    }
}
