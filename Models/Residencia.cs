namespace Soltrix.Models
{
    using System;

    /// <summary>
    /// Representa uma residência cadastrada no sistema.
    /// </summary>
    public class Residencia
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Endereco Endereco { get; set; }
        public Usuario Proprietario { get; set; }
    }

}
