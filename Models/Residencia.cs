using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soltrix.Models
{
    using System;

    public class Residencia
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Endereco Endereco { get; set; }
        public Usuario Proprietario { get; set; }
    }

}
