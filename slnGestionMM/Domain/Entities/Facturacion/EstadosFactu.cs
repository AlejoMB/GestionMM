using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Facturacion
{
    public class EstadosFactu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<FacturaEnc> FacturaEnc { get; } = new List<FacturaEnc>();
    }
}
