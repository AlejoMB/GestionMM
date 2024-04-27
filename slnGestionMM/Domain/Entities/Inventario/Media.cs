using Domain.Entities.Compras;
using Domain.Entities.Facturacion;
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
        public string Imagen { get; set; }
        //public int IdBodega { get; set; }
        public Bodega? Bodega { get; set; }
        //public int IdProveedor { get; set; }
        public Tamano? Tamano { get; set; }
        //public int IdTipoMedia { get; set; }
        public TipoMedia? TipoMedia { get; set; }
        //public int IdMarca { get; set; }
        public Marca? Marca { get; set; }
        //public int IdColor { get; set; }
        //public int IdDiseno { get; set; }
        public Diseno? Diseno { get; set; }
        //public int IdSegmento { get; set; }
        public Segmento? Segmento { get; set; }
        public List<MediaColores> MediaColores { get; set; }
        public ICollection<ComprasDetalle> ComprasDetalle { get; } = new List<ComprasDetalle>();
        public ICollection<Existencias> Existencias { get; } = new List<Existencias>();
        public ICollection<FacturaDetalle> FacturaDetalle { get; } = new List<FacturaDetalle>(); 

    }
}
