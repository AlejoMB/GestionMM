using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Inventario
{
    public class Media
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdBodega { get; set; }
        public Bodega Bodega { get; set; }
        public int IdProveedor { get; set; }
        public Proveedor Proveedor { get; set; }
        public int IdTamano { get; set; }
        public Tamano Tamano { get; set; }
        public int IdTipoTela { get; set; }
        public TipoTela TipoTela { get; set; }

    }
}
