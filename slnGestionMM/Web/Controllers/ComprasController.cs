using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Helpers;
using Domain.Models.Inventario;
using Services.Inventario;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Web.Controllers
{
    public class ComprasController : Controller
    {
        private GestionDbContext _dbContext;
        private MediaService _mediaService;
        const string URLImages = "https://localhost:7155/imagenes/";
        public ComprasController(GestionDbContext dbContext)
        {
            _dbContext = dbContext;
            _mediaService = new MediaService(_dbContext);
        }

        public IActionResult Index()
        {
            ViewBag.UlrHost = URLImages;
            var proveedores = _dbContext.Proveedores.ToList();

            ViewBag.Proveedores = proveedores;

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

            return View();
        }

        public IActionResult BuscarMedias([FromForm] AddProductoModel model)
        {
            var result = _mediaService.SearchMedia(model)
                                      .Select(p => new AddProductoModel { 
                                          ColoresText = p.MediaColores.Select(mc => mc.Color.RgbColor + "_" + mc.Color.Name).ToList(),
                                          DisenoText = p.Diseno.Name,
                                          MarcaText = p.Marca.Name,
                                          Name = p.Name,
                                          Imagen = p.Imagen,
                                          SegmentoText = p.Segmento.Name,
                                          TamanoText = p.Tamano.Name,
                                          TipoMediaText = p.TipoMedia.Name
                                      }).ToList();

            var jsonData = JsonConvert.SerializeObject(result);

            return Ok(jsonData);
        }
    }
}
