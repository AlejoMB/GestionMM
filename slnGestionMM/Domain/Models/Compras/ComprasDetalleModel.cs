using Domain.Entities.Inventario;

namespace Domain.Models.Compras
{
    public class ComprasDetalleModel
    {
        public int Media { get; set; }
        public int CostoUnitario { get; set; }
        public int Cantidad { get; set; }
        public string Total { get; set; }
    }
}
