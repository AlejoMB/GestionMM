using Domain.Entities.Compras;
using Domain.Entities.Facturacion;
using Domain.Models.Compras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Facturas
{
    public class FacturaEncModel
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Total { get; set; }
        public int EstadoFactu { get; set; }
        public int TipoEnvio { get; set; }
        public string? NoGuia { get; set; }
        public int MedioPago { get; set; }
        public int Transportadora { get; set; }
        public DateTime FechaPago { get; set; }
        public string DetalleString { get; set; }
        public List<FacturaDetalleModel> Detalles { get; set; }
    }
}
