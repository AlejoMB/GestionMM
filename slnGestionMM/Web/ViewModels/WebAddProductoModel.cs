using Domain.Models.Inventario;

namespace Web.ViewModels
{
    public class WebAddProductoModel: AddProductoModel
    {
        public IFormFile Imagen { get; set; }
    }
}
