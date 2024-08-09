using Domain.Entities.Facturacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.FactuEnc
{
    public class FactuEncModel
    {
        public IEnumerable<FacturaEnc> Facutras { get; set; }
        public string Ano { get; set; }
        public string Mes { get; set; }
        public string NoFactura { get; set; }
    }
}
