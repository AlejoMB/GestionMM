using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Informes
{
    public class InformeEncFactu
    {
        public int IdFactu { get; set; }
        public List<InformeFactuDetalle> Detalles { get; set; }
        public int TotalVenta { get; set; }
        public int TotalACosto { get; set; }
        public int TotalGanancia { get; set; }
    }
}
