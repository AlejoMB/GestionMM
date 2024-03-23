using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Inventario
{
    public class Marca
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Media> Medias { get; } = new List<Media>();
    }
}
