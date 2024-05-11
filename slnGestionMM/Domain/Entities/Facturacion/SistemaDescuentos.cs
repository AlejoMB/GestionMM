using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Facturacion
{
    public class SistemaDescuentos
    {
        public int Id { get; set; }
        public int Minimo { get; set; }
        public int Maximo { get; set; }
        public int SobreCosto { get; set; }
    }
}
