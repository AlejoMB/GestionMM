using Domain.Entities.Facturacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Compras
{
    public class MedioPago
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ComprasEnc> ComprasEnc { get; } = new List<ComprasEnc>();
        public ICollection<FacturaEnc> FacturaEnc { get; } = new List<FacturaEnc>();
    }
}
