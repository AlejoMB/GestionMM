using Domain.Entities.Compras;

namespace Domain.Models.Compras
{
    public class ComprasEncModel
    {
        public int Proveedor { get; set; }
        public int MedioPago { get; set; }
        public int Pagado { get; set; } //Estado
        public int Total { get; set; }
        public List<ComprasDetalleModel> Detalle { get; set; }
        public CategoriasModel Categorias { get; set; }
    }
}
