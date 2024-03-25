using Domain;
using Domain.Entities.Inventario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Web.Models;
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
                         .Include(medias => medias.MediaColores).ThenInclude(mediacolores => mediacolores.Color)
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
            ViewBag.RowsColores = CrearTablaColores(colores);
            ViewBag.Disenos = new SelectList(disenos, "Id", "Name");
            ViewBag.Segmentos = new SelectList(segmentos, "Id", "Name");

            ViewBag.UlrHost = URLImages;

            return View();
        }

        public List<ColoresModel> CrearTablaColores(List<Color> colores)
        {
            var rowsColoresModel = new List<ColoresModel>();
            var contColores = 1;
            var rowColorModel = new ColoresModel();
            rowColorModel.Colores = new List<Color>();
            foreach (var color in colores) 
            {
                if (contColores % 3 == 0)
                {
                    rowColorModel.Colores.Add(color);
                    rowsColoresModel.Add(rowColorModel);
                    rowColorModel = new ColoresModel();
                    rowColorModel.Colores = new List<Color>();
                }
                else
                {
                    rowColorModel.Colores.Add(color);
                }

                if (contColores == colores.Count() && contColores % 3 != 0)
                {
                    rowsColoresModel.Add(rowColorModel);
                }

                contColores++;
            }

            return rowsColoresModel;
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
                Imagen = model.Name + ".png"

            };

            media.TipoMedia = _dbContext.TipoMedias.FirstOrDefault(x => x.Id == model.TipoMediaId);
            media.Tamano = _dbContext.Tamanos.FirstOrDefault(x => x.Id == model.TamanoId);
            media.Marca = _dbContext.Marcas.FirstOrDefault(x => x.Id == model.MarcaId);
            //media.Color = _dbContext.Colores.FirstOrDefault(x => x.Id == Convert.ToInt32(model.ColorId));
            media.Diseno = _dbContext.Disenos.FirstOrDefault(x => x.Id == model.DisenoId);
            media.Segmento = _dbContext.Segmentos.FirstOrDefault(x => x.Id == model.SegmentoId);

            var listaColores = new List<MediaColores>();
            foreach(var color in model.Colores)
            {
                var mediaColor = new MediaColores();
                mediaColor.Color = _dbContext.Colores.FirstOrDefault(x => x.Id == color);
                listaColores.Add(mediaColor);
            }
            media.MediaColores = listaColores;

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
                .Include(m => m.MediaColores)
                .Include(m => m.Diseno)
                .Include(m => m.Segmento)
                .FirstOrDefault(m => m.TipoMedia.Id.Equals(model.TipoMediaId) &&
                                     m.Tamano.Id.Equals(model.TamanoId) &&
                                     m.Marca.Id.Equals(model.MarcaId) &&
                                     (m.MediaColores.All(mc => model.Colores.Contains(mc.Color.Id)) && model.Colores.Count == m.MediaColores.Count) &&
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
