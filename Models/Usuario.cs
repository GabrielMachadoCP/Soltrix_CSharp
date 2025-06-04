using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soltrix.Models
{

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
