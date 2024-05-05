using Domain.Entities.Compras;
using Domain.Entities.Facturacion;

namespace Web.ViewModels
{
    public class FacturaEncModel
    {
        public int ClienteId { get; set; }
        public int Total { get; set; }
        public int EstadoFactu { get; set; }
        public int TipoEnvioId { get; set; }
        public string? NoGuia { get; set; }
        public int MedioPagoId { get; set; }
        public int? TransportadoraId { get; set; }
        
    }
}
