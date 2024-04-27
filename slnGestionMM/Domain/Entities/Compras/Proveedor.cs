using Domain.Entities.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Compras
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public ICollection<ComprasEnc> ComprasEnc { get; } = new List<ComprasEnc>();
    }
}
