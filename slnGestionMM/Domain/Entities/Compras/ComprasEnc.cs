using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Compras
{
    public class ComprasEnc
    {
        public int Id { get; set; }
        public Proveedor Proveedor { get; set; }
        public MedioPago MedioPago { get; set; }
        public DateTime FechaPago { get; set; }
        public bool Pagado { get; set; } //Estado
        public int Total { get; set; }
        public int CreadoPorUser { get; set; }
        public DateTime FechaCreado { get; set; }
        public ICollection<ComprasDetalle> ComprasDetalle { get; set; } = new List<ComprasDetalle>();
    }
}
