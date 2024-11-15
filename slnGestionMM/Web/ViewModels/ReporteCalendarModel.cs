using Domain.Entities.Facturacion;

namespace Web.ViewModels
{
    public class ReporteCalendarModel
    {
        public int Mes { get; set; }
        public List<List<DateTime>> Calendario { get; set; }
        public Dictionary<DateTime, List<FacturaEnc>> VentasPorDia { get; set; }
    }
}
