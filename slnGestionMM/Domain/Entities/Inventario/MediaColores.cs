using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Inventario
{
    public class MediaColores
    {
        public int Id { get; set; }
        public Media? Media { get; set; }
        public Color? Color { get; set; }
    }
}
