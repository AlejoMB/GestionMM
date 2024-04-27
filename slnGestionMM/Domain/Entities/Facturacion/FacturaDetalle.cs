using Domain.Entities.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Facturacion
{
    public class FacturaDetalle
    {
        public int Id { get; set; }
        public FacturaEnc Encabezado { get; set; }
        public int PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public Media Media { get; set; }
        public int Total { get; set; }
    }
}
