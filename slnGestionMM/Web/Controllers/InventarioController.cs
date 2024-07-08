using Domain;
using Domain.Entities.Inventario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Helpers;
using Domain.Models.Inventario;
using Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Web.Controllers
{
    public class InventarioController : Controller
    {
        private GestionDbContext _dbContext;
        private readonly IWebHostEnvironment _env;
        const string URLImages = "https://www.mediaslunas.com/imagenes/";
        public InventarioController(GestionDbContext dbContext, IWebHostEnvironment env)
        {
            _dbContext = dbContext;
            _env = env;
        }

        //[Authorize(Roles = "Administrador")] 
        public IActionResult Index(string selectedTab)
        {
            //var catalogo = new List<CatalogoModel>();
            int categoria = 0;
            if(!String.IsNullOrEmpty(selectedTab))
            {
                var values = selectedTab.Split('_');
                categoria = values[1].ToLower() == "false" ? 0 : int.Parse(values[0]);
            }

            ViewBag.UlrHost = URLImages;
            var tiposMedias = _dbContext.TipoMedias.Select(c => new CatalogoModel { IdCategoria = c.Id, Name = c.Name }).ToList();
            var tamanos = _dbContext.Tamanos.Select(t => new TamanoModel { Id = t.Id, Name = t.Name } ).ToList();
            var medias = _dbContext.Medias.Where(m => m.TipoMedia.Id == categoria)
                         .Include(medias => medias.TipoMedia)
                         .Include(medias => medias.Tamano)
                         .Include(medias => medias.Marca)
                         .Include(medias => medias.MediaColores).ThenInclude(mediacolores => mediacolores.Color)
                         .Include(medias => medias.Diseno)
                         .Include(medias => medias.Segmento)
                         .Include(medias => medias.Existencias)
                         .ToList();

            foreach (var item in tiposMedias)
            {
                //item.Tamanos = tamanos;
                item.Tamanos = tamanos.Select(t => new TamanoModel { Id = t.Id, Name = t.Name }).ToList();
                foreach (var tamano in item.Tamanos)
                {
                    tamano.Medias = new List<Media>();
                    var mediasResult = medias.Where(m => m.TipoMedia.Id == item.IdCategoria && m.Tamano?.Id == tamano.Id).ToList();
                    tamano.Medias.AddRange(mediasResult);
                }

            }


            return View(tiposMedias);
        }

        [Authorize]
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
            ViewBag.RowsColores = ViewHelpers.CrearTablaColores(colores);
            ViewBag.Disenos = new SelectList(disenos, "Id", "Name");
            ViewBag.Segmentos = new SelectList(segmentos, "Id", "Name");

            ViewBag.UlrHost = URLImages;

            return View();
        }

        [HttpPost]
        public IActionResult UploadImage([FromForm] WebAddProductoModel model)
        {
            var result = ProductExists(model);
            if(result != null)
            {
                return this.Problem("Media existente con nombre:" + result);
            }

            string mediaName = model.Name.Trim();

            var media = new Media()
            {
                Name = model.Name,
                Imagen = "Guardado Inicial"//mediaName.Replace(" ","_") + ".png"

            };

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            media.TipoMedia = _dbContext.TipoMedias.FirstOrDefault(x => x.Id == model.TipoMediaId);
            media.Tamano = _dbContext.Tamanos.FirstOrDefault(x => x.Id == model.TamanoId);
            media.Marca = _dbContext.Marcas.FirstOrDefault(x => x.Id == model.MarcaId);
            //media.Color = _dbContext.Colores.FirstOrDefault(x => x.Id == Convert.ToInt32(model.ColorId));
            media.Diseno = _dbContext.Disenos.FirstOrDefault(x => x.Id == model.DisenoId);
            media.Segmento = _dbContext.Segmentos.FirstOrDefault(x => x.Id == model.SegmentoId);
            media.FechaCreado = DateTime.Now;
            media.CreadoPorUser = userId;

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

            media.Imagen = mediaName.Replace(" ", "_")+ "_" + media.Id + ".png";

            _dbContext.Medias.Update(media);
            _dbContext.SaveChanges();

            string filePath = GetFilePath(mediaName.Replace(" ", "_"))+ "_" + media.Id + ".png";
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            using (FileStream stream = System.IO.File.Create(filePath))
            {
                model.Imagen.CopyTo(stream);
            }

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
                .FirstOrDefault(m => m.Name == model.Name &&
                                     m.TipoMedia.Id.Equals(model.TipoMediaId) &&
                                     m.Tamano.Id.Equals(model.TamanoId) &&
                                     m.Marca.Id.Equals(model.MarcaId) &&
                                     (m.MediaColores.All(mc => model.Colores.Contains(mc.Color.Id)) && model.Colores.Count == m.MediaColores.Count) &&
                                     m.Diseno.Id.Equals(model.DisenoId) &&
                                     m.Segmento.Id.Equals(model.SegmentoId));
            if(media != null)
            {
                return media.Name + "|" + media.Imagen;
            }
            return null;
        }

        public string GetFilePath (string productCode)
        {
            return _env.WebRootPath + "\\Imagenes\\" + productCode;
        }
    }
}
