using Soltrix.Models;
using System.Collections.Generic;
using System.Linq;

namespace Soltrix.Services
{
    public class EnergiaService
    {
        private List<EventoEnergia> _eventos = new();

        public void RegistrarEvento(EventoEnergia evento)
        {
            _eventos.Add(evento);
        }

        public IEnumerable<EventoEnergia> ObterEventosPorData(System.DateTime data)
        {
            return _eventos.Where(e => e.DataHora.Date == data.Date);
        }

        public List<EventoEnergia> ObterEventosPorUsuario(string cpf)
        {
            return _eventos.Where(e => e.UsuarioCPF == cpf).ToList();
        }

        public List<EventoEnergia> ObterTodosEventos() => _eventos;
    }
}
