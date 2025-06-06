namespace Soltrix.Models
{
    /// <summary>
    /// Representa um estabelecimento comercial ou empresarial associado a um usuário.
    /// </summary>
    public class Estabelecimento
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public Endereco Localizacao { get; set; }
    }

}
