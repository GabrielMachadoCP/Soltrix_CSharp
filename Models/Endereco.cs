namespace Soltrix.Models
{
    /// <summary>
    /// Representa um endereço completo com informações de localização.
    /// </summary>
    public class Endereco
    {
        public string CEP { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        /// <summary>
        /// Retorna a representação em string do endereço completo.
        /// </summary>
        public string ExibirEndereco()
        {
            return $"{Rua}, {Numero} - {Bairro}, {Cidade} - {Estado}, CEP: {CEP}";
        }
    }

}
