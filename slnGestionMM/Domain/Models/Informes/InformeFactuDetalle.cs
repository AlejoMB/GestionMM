using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Informes
{
    public class InformeFactuDetalle
    {
        public int idMedia { get; set; }
        public int PrecioVenta { get; set; }
        public int PrecioCompra { get; set; }
        public int Cantidad { get; set; }
        public int TotalVenta { get; set; }
        public int TotalACosto { get; set; }
    }
}
