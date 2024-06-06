using Domain.Entities.Facturacion;
using Domain.Entities.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Facturas
{
    public class FacturaDetalleModel
    {

        public int Media { get; set; }
        public int PrecioUnitario { get; set; }
        public int Cantidad { get; set; }        
        public int Total { get; set; }
    }
}
