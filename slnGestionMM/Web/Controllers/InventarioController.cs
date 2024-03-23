using Domain;
using Domain.Entities.Inventario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Web.Models.Inventario;

namespace Web.Controllers
{
    public class InventarioController : Controller
    {
        private GestionDbContext _dbContext;
        private readonly IWebHostEnvironment _env;
        const string URLImages = "https://localhost:7155/imagenes/";
        public InventarioController(GestionDbContext dbContext, IWebHostEnvironment env)
        {
            _dbContext = dbContext;
            _env = env;
        }

        public IActionResult Index()
        {
            ViewBag.UlrHost = URLImages;
            var medias = _dbContext.Medias
                         .Include(medias => medias.TipoMedia)
                         .Include(medias => medias.Tamano)
                         .Include(medias => medias.Marca)
                         .Include(medias => medias.Color)
                         .Include(medias => medias.Diseno)
                         .Include(medias => medias.Segmento)
                         .ToList();
            return View(medias);
        }

        public IActionResult AddProducto()
        {
            var tiposMedias = _dbContext.TipoMedias.ToList();
            var tamanos = _dbContext.Tamanos.ToList();
            var marcas = _dbContext.Marcas.ToList();
            var colores = _dbContext.Colores.ToList();
            var disenos = _dbContext.Disenos.ToList();
            var segmentos = _dbContext.Segmentos.ToList();

            ViewBag.TiposMedias = new SelectList(tiposMedias, "Id", "Name");
            ViewBag.Tamanos = new SelectList(tamanos, "Id", "Name");
            ViewBag.Marcas = new SelectList(marcas, "Id", "Name");
            ViewBag.Colores = colores;
            ViewBag.Disenos = new SelectList(disenos, "Id", "Name");
            ViewBag.Segmentos = new SelectList(segmentos, "Id", "Name");

            ViewBag.UlrHost = URLImages;

            return View();
        }

        [HttpPost]
        public IActionResult UploadImage([FromForm] AddProductoModel model)
        {
            var result = ProductExists(model);
            if(result != null)
            {
                return this.Problem("Media existente con nombre:" + result);
            }

            string filePath = GetFilePath(model.Name) + ".png";
            if(System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            using(FileStream stream = System.IO.File.Create(filePath))
            {
                model.Imagen.CopyTo(stream);
            }

            var media = new Media()
            {
                Name = model.Name,
                Imagen = model.Name

            };

            media.TipoMedia = _dbContext.TipoMedias.FirstOrDefault(x => x.Id == Convert.ToInt32(model.TipoMediaId));
            media.Tamano = _dbContext.Tamanos.FirstOrDefault(x => x.Id == Convert.ToInt32(model.TamanoId));
            media.Marca = _dbContext.Marcas.FirstOrDefault(x => x.Id == Convert.ToInt32(model.MarcaId));
            media.Color = _dbContext.Colores.FirstOrDefault(x => x.Id == Convert.ToInt32(model.ColorId));
            media.Diseno = _dbContext.Disenos.FirstOrDefault(x => x.Id == Convert.ToInt32(model.DisenoId));
            media.Segmento = _dbContext.Segmentos.FirstOrDefault(x => x.Id == Convert.ToInt32(model.SegmentoId));


            _dbContext.Medias.Add(media);
            _dbContext.SaveChanges();

            return Ok("Image uploaded successfully");
        }

        public string ProductExists(AddProductoModel model)
        {
            var media = _dbContext.Medias
                .Include(m => m.TipoMedia)
                .Include(m => m.Tamano)
                .Include(m => m.Marca)
                .Include(m => m.Color)
                .Include(m => m.Diseno)
                .Include(m => m.Segmento)
                .FirstOrDefault(m => m.TipoMedia.Id.Equals(model.TipoMediaId) &&
                                     m.Tamano.Id.Equals(model.TamanoId) &&
                                     m.Marca.Id.Equals(model.MarcaId) &&
                                     m.Color.Id.Equals(model.ColorId) &&
                                     m.Diseno.Id.Equals(model.DisenoId) &&
                                     m.Segmento.Id.Equals(model.SegmentoId));
            if(media != null)
            {
                return media.Name + "_" + media.Imagen;
            }
            return null;
        }

        public string GetFilePath (string productCode)
        {
            return _env.WebRootPath + "\\Imagenes\\" + productCode;
        }
    }
}
