using Soltrix.Models;

namespace Soltrix.Utils
{
    /// <summary>
    /// Calculadora simples para estimar prejuízo financeiro com base em eventos de falha de energia.
    /// </summary>
    public static class CalculadoraPrejuizo
    {
        private const decimal PrejuizoPorHora = 50.00m;


        /// <summary>
        /// Calcula o prejuízo total somando um valor fixo para cada evento de falha.
        /// </summary>
        /// <param name="eventos">Lista de eventos de energia.</param>
        /// <returns>Valor total estimado do prejuízo.</returns>
        public static decimal CalcularPrejuizo(List<EventoEnergia> eventos)
        {
            decimal total = 0;

            foreach (var evento in eventos)
            {
                total += PrejuizoPorHora;
            }

            return total;
        }
    }
}