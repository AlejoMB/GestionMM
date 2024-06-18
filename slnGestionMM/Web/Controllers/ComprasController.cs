using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Helpers;
using Domain.Models.Inventario;
using Services.Inventario;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Web.ViewModels;
using Domain.Models.Compras;
using Domain.Entities.Compras;
using Domain.Entities.Inventario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Web.Controllers
{
    [Authorize]
    public class ComprasController : Controller
    {
        private GestionDbContext _dbContext;
        private MediaService _mediaService;
        const string URLImages = "http://www.mediaslunas.com/imagenes/";
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
                                          Id = p.Id,
                                          ColoresText = p.MediaColores.Select(mc => mc.Color.RgbColor + "_" + mc.Color.Name).ToList(),
                                          DisenoText = p.Diseno.Name,
                                          MarcaText = p.Marca.Name,
                                          Name = p.Name,
                                          Imagen = p.Imagen,
                                          SegmentoText = p.Segmento.Name,
                                          TamanoText = p.Tamano.Name,
                                          TipoMediaText = p.TipoMedia.Name,
                                          Existencia = p.Existencias == null ? 0 : p.Existencias.CantidadProducto
                                      }).ToList();

            var jsonData = JsonConvert.SerializeObject(result);

            return Ok(jsonData);
        }

        [HttpPost]
        public IActionResult CrearCompra([FromForm] ComprasEncModel model)
        {
            model.Detalles = JsonConvert.DeserializeObject<List<ComprasDetalleModel>>(model.DetalleString);
            var claims = this.User.Claims;

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var compraEncab = new ComprasEnc()
            {
                Proveedor = _dbContext.Proveedores.FirstOrDefault(p => p.Id == model.Proveedor),
                MedioPago = _dbContext.MedioPago.FirstOrDefault(m => m.Id == model.MedioPago),
                FechaPago = model.FechaPago,
                Pagado = Convert.ToBoolean(model.Pagado),
                Total = model.Total,
                FechaCreado = DateTime.Now,
                CreadoPorUser = userId
            };

            foreach (var detalleModel in model.Detalles)
            {
                var media = _dbContext.Medias.FirstOrDefault(m => m.Id == detalleModel.Media);
                var comprasDetalle = new ComprasDetalle() { 
                    Media = media,
                    CostoUnitario = detalleModel.CostoUnitario,
                    Cantidad = detalleModel.Cantidad,
                    Total = detalleModel.Total

                };

                compraEncab.ComprasDetalle.Add(comprasDetalle);
                AddExistencia(media, detalleModel.Cantidad);
                //_dbContext.Existencias.Update(GetExistencia(media, detalleModel.Cantidad));
            }

            _dbContext.ComprasEnc.Add(compraEncab);
            _dbContext.SaveChanges();


            return Ok("Compra saved successfully");
        }

        public void AddExistencia(Media media,int cantidad)
        {
            var existencia = _dbContext.Existencias.FirstOrDefault(e => e.MediaRef == media.Id);
            if(existencia == null)
            {
                _dbContext.Existencias.Add( new Existencias { 
                    MediaRef = media.Id,
                    CantidadProducto = cantidad
                    
                });
            }
            else
            {
                existencia.CantidadProducto += cantidad;
                _dbContext.Existencias.Update(existencia);
            }
        }

        [HttpGet]
        public IActionResult GetMediaName(int codigoMedia)
        {
            var media = _dbContext.Medias.FirstOrDefault(c => c.Id == codigoMedia);
            return media == null ? NotFound() : Ok(media.Name);
        }
    }
}
