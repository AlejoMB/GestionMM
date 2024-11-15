using Domain.Entities.Gastos;

namespace Web.ViewModels
{
    public class ReporteVentasModel
    {
        public int Mes { get; set; }
        public List<IGrouping<int,VentasModel>> Ventas { get; set; }
        public List<Gastos> Gastos { get; set; }
        public InventarioModel Inventario { get; set; }

    }
}
