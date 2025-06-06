namespace Soltrix.Models
{
    /// <summary>
    /// Representa um evento de queda ou retorno de energia registrado por um usuário.
    /// </summary>
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
