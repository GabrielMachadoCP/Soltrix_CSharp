using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soltrix.Models
{
    using System;

    public class Backup
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public string DadosJson { get; set; }
        public string LocalDestino { get; set; }
    }

}
