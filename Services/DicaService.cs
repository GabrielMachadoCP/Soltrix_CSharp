using Soltrix.Models;
using System.Collections.Generic;

namespace Soltrix.Services
{
    /// <summary>
    /// Serviço responsável por fornecer dicas relacionadas a eventos de falta de energia.
    /// </summary>
    public class DicaService
    {
        /// <summary>
        /// Obtém uma lista de dicas para serem seguidas antes da falta de energia.
        /// </summary>
        /// <returns>Lista de dicas para o período antes da falta de energia.</returns>
        public List<Dica> ObterDicasAntes()
        {
            return new List<Dica>
            {
                new("Estoque de Velas e Lanternas", "Tenha lanternas e velas em locais de fácil acesso."),
                new("Bateria Carregada", "Mantenha celulares e powerbanks sempre carregados."),
                new("Água e Alimentos", "Tenha sempre alimentos não perecíveis e água potável armazenados.")
            };
        }

        /// <summary>
        /// Obtém uma lista de dicas para serem seguidas durante a falta de energia.
        /// </summary>
        /// <returns>Lista de dicas para o período durante a falta de energia.</returns>
        public List<Dica> ObterDicasDurante()
        {
            return new List<Dica>
            {
                new("Evite Abrir a Geladeira", "Ajuda a conservar os alimentos por mais tempo."),
                new("Desligue os Aparelhos", "Evita danos quando a energia retornar."),
                new("Use Luz Natural", "Durante o dia, aproveite ao máximo a luz do sol.")
            };
        }

        /// <summary>
        /// Obtém uma lista de dicas para serem seguidas depois da falta de energia.
        /// </summary>
        /// <returns>Lista de dicas para o período após a falta de energia.</returns>
        public List<Dica> ObterDicasDepois()
        {
            return new List<Dica>
            {
                new("Verifique Aparelhos", "Ligue os equipamentos um a um e observe se funcionam corretamente."),
                new("Relate Falhas", "Comunique a concessionária sobre falhas persistentes."),
                new("Reorganize seu Kit", "Reponha velas, baterias e outros itens utilizados.")
            };
        }
    }
}
