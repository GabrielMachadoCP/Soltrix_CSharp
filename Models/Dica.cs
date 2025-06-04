namespace Soltrix.Models
{
    public class Dica
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        public Dica(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;
        }

        public override string ToString()
        {
            return $"-> {Titulo}: {Descricao}";
        }
    }
}
