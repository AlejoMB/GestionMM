using Microsoft.EntityFrameworkCore;

namespace Domain.Models.Inventario
{
    public class AddProductoModel
    {
        public int Id { get; set; }
        public int? TipoMediaId { get; set; }
        public string TipoMediaText { get; set; }
        public int? TamanoId { get; set; }
        public string TamanoText { get; set; }
        public int? MarcaId { get; set; }
        public string MarcaText { get; set; }
        public List<int> Colores { get; set; }
        public List<string> ColoresText { get; set; }
        public int? DisenoId { get; set; }
        public string DisenoText { get; set; }
        public int? SegmentoId { get; set; }
        public string SegmentoText { get; set; }
        public string Name { get; set; }
        public string Imagen { get; set; }
        public int Existencia { get; set; }
        //public IFormFile Imagen { get; set; }
    }
}
