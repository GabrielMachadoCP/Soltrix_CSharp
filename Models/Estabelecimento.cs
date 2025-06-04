using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soltrix.Models
{
    public class Estabelecimento
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public Endereco Localizacao { get; set; }
    }

}
