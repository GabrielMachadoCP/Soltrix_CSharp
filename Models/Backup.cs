namespace Soltrix.Models
{
    using System;

    /// <summary>
    /// Representa um backup contendo dados salvos do sistema.
    /// </summary>
    public class Backup
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public string DadosJson { get; set; }
        public string LocalDestino { get; set; }
    }

}
