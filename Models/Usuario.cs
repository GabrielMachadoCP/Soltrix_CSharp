namespace Soltrix.Models
{

    /// <summary>
    /// Representa um usuário do sistema Soltrix, contendo dados pessoais e informações de endereço.
    /// </summary>
    public class Usuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public Endereco Endereco { get; set; }
        public string SenhaHash { get; set; }
        public bool PossuiEstabelecimento { get; set; }
        public Estabelecimento Estabelecimento { get; set; }
    }

}
