using Domain.Entities.Compras;

namespace Domain.Models.Compras
{
    public class ComprasEncModel
    {
        public int Proveedor { get; set; }
        public int MedioPago { get; set; }
        public DateTime FechaPago { get; set; }
        public string Pagado { get; set; } //Estado
        public string Total { get; set; }
        public int UserId { get; set; }
        public List<ComprasDetalleModel> Detalles { get; set; }
        public string DetalleString { get; set; }
        public CategoriasModel Categorias { get; set; }
    }
}
