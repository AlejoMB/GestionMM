namespace Domain.Models
{
    public class CategoriasModel
    {
        public int? TipoMediaId { get; set; }
        public int? TamanoId { get; set; }
        public int? MarcaId { get; set; }
        public List<int> Colores { get; set; }
        public int? DisenoId { get; set; }
        public int? SegmentoId { get; set; }
        public string Name { get; set; }
    }
}
