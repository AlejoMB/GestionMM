using Domain.Entities.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Facturacion
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Cedula  { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public string? Direccion { get; set; }
        public ICollection<FacturaEnc> FacturaEnc { get; } = new List<FacturaEnc>();
    }
}
