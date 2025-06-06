namespace Soltrix.Models
{

    /// <summary>
    /// Representa uma dica exibida para o usuário, com título e descrição.
    /// </summary>
    public class Dica
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        public Dica(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;
        }

        /// <summary>
        /// Retorna uma representação em string da dica.
        /// </summary>
        /// <returns>Uma string formatada com título e descrição.</returns>
        public override string ToString()
        {
            return $"-> {Titulo}: {Descricao}";
        }
    }
}
