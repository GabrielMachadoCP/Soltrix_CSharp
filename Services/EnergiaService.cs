using Soltrix.Models;
using System.Collections.Generic;
using System.Linq;

namespace Soltrix.Services
{
    /// <summary>
    /// Serviço para registrar e consultar eventos de energia.
    /// </summary>
    public class EnergiaService
    {
        private List<EventoEnergia> _eventos = new();


        /// <summary>
        /// Registra um novo evento de energia.
        /// </summary>
        /// <param name="evento">O evento de energia a ser registrado.</param>
        public void RegistrarEvento(EventoEnergia evento)
        {
            _eventos.Add(evento);
        }


        /// <summary>
        /// Obtém os eventos de energia relacionados a um usuário pelo CPF.
        /// </summary>
        /// <param name="cpf">CPF do usuário para filtrar eventos.</param>
        /// <returns>Lista de eventos do usuário.</returns>
        public List<EventoEnergia> ObterEventosPorUsuario(string cpf)
        {
            return _eventos.Where(e => e.UsuarioCPF == cpf).ToList();
        }

    }
}
