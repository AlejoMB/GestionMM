using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Compras
{
    public class MedioPagoCompras
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public ICollection<ComprasEnc> ComprasEnc { get; } = new List<ComprasEnc>();
    }
}
