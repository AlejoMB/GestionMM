using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Informes
{
    public class InformesModel
    {
        public string txtAnoValue { get; set; }
        public string txtMesValue { get; set; }
        public List<InformeEncFactu> Facturas { get; set; } = new List<InformeEncFactu>();
        public int TotalVentaMes { get; set; }
        public int TotalACostoMes { get; set; }
        public int TotalGananciaMes { get; set; }
        public int TotalGastos { get; set; }
    }
}
