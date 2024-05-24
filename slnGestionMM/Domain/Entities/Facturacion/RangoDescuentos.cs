using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Facturacion
{
    public class RangoDescuentos
    {
        public int Id { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int Valor { get; set; }
    }
}
