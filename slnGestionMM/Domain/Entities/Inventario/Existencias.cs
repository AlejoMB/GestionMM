using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Inventario
{
    public class Existencias
    {
        public int Id { get; set; }
        public Media Media { get; set; }
        public int MediaRef { get; set; }
        public int CantidadProducto { get; set; }
        [Timestamp]
        public byte[] Version { get; set; }
    }
}
