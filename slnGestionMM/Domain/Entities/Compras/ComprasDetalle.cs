using Domain.Entities.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Compras
{
    public class ComprasDetalle
    {
        public int Id { get; set; }
        public ComprasEnc Encabezado { get; set; }
        public Media Media { get; set; }
        public int CostoUnitario { get; set; }
        public int Cantidad { get; set; }
        public int Total {  get; set; }

    }
}
