using Domain.Entities.Inventario;

namespace Web.ViewModels
{
    public class CatalogoModel
    {
        public int IdCategoria { get; set; }
        public string Name { get; set; }
        public List<Media> Medias { get; set; } = new List<Media>();
    }
}
