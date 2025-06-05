using Soltrix.Models;

namespace Soltrix.Utils
{
    public static class CalculadoraPrejuizo
    {
        private const decimal PrejuizoPorHora = 50.00m;

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