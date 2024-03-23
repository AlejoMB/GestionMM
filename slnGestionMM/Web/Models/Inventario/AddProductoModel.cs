using Microsoft.EntityFrameworkCore;

namespace Web.Models.Inventario
{
    public class AddProductoModel
    {
        public int? TipoMediaId { get; set; }
        public int? TamanoId { get; set; }
        public int? MarcaId { get; set; }
        public int? ColorId { get; set; }
        public int? DisenoId { get; set; }
        public int? SegmentoId { get; set; }
        public string Name { get; set; }        
        public IFormFile Imagen { get; set; }






    }
}
