using Domain.Entities.Compras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Facturacion
{
    public class FacturaEnc
    {
        public int Id { get; set; }
        public Clientes Cliente { get; set; }
        public int Total { get; set; }
        public EstadosFactu EstadoFactu { get; set; }
        public TipoEnvios TipoEnvio { get; set; }
        public string? NoGuia { get; set; }
        public MedioPago MedioPago { get; set; }
        public Transportadora? Transportadora { get; set; }
        public int CreadoPorUser { get; set; }
        public DateTime FechaCreado { get; set; }
        public ICollection<FacturaDetalle> FacturaDetalle { get; set; } = new List<FacturaDetalle>();
    }
}
