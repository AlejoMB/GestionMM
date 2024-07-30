using Domain;
using Domain.Entities.Facturacion;
using Domain.Entities.Inventario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using Web.Helpers;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Facturas;
using Domain.Models.Compras;
using Newtonsoft.Json;
using Domain.Entities.Compras;
using Microsoft.AspNetCore.Authorization;
using Domain.Entities.Authorization;
using System.Security.Claims;

namespace Web.Controllers
{
    [Authorize]
    public class FacturacionController : Controller
    {
        private GestionDbContext _dbContext;
        const string URLImages = "https://www.mediaslunas.com/imagenes/";

        public FacturacionController(GestionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var tiposEnvios = _dbContext.TipoEnvio.ToList();
            var transportadora = _dbContext.Transportadora.ToList();
            var medioPago = _dbContext.MedioPago.ToList();

            ViewBag.TiposEnvios = new SelectList(tiposEnvios, "Id", "Name"); 
            ViewBag.Transportadora = new SelectList(transportadora, "Id", "Name");
            ViewBag.MedioPago = new SelectList(medioPago, "Id", "Name");


            //Valores buscador Medias
            ViewBag.UlrHost = URLImages;
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

            ViewBag.Descuentos = GetDescuentos();

            return View();
        }

        [HttpGet]
        public IActionResult GetCliente(string celular)
        {
            var cliente = _dbContext.Cliente.FirstOrDefault(c => c.Celular == celular);
            return cliente == null ? NotFound() : Ok(cliente);
        }

        [HttpGet]
        public IActionResult GetCostoProrateo(int idMedia)
        {
            var compras = _dbContext.ComprasDetalle.Where(c => c.Media.Id == idMedia);
            int costoCompra = 0;
            int costoProrateoCompra = 0;
            
            foreach (var compra in compras)
            {
                costoCompra += compra.CostoUnitario;
            }
                
            if(costoCompra > 0)
            {
                costoProrateoCompra = costoCompra / compras.Count();
            }

            return Ok(costoProrateoCompra);
        }

        [HttpPost]
        public IActionResult CrearCliente(Clientes clienteModel)
        {
            var cliente = _dbContext.Cliente.FirstOrDefault(c => c.Cedula == clienteModel.Cedula);
            
            if (cliente != null)
                return NotFound();

            var result = _dbContext.Cliente.Add(clienteModel);
            _dbContext.SaveChanges();

            return Ok(result.Entity);
        }

        public string GetDescuentos()
        {
            var descuentos = _dbContext.RangoDescuentos.ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var descuento in descuentos) 
            {
                sb.Append("|");
                sb.Append(descuento.Min);
                sb.Append(";");
                sb.Append(descuento.Max);
                sb.Append(";");
                sb.Append(descuento.Valor);
            }

            return sb.ToString();
        }

        [HttpGet]
        public IActionResult GetMediaName(int codigoMedia)
        {
            var media = _dbContext.Medias.Include(m => m.Existencias).FirstOrDefault(c => c.Id == codigoMedia);
            if (media != null)
            {
                string existencia = media.Existencias?.CantidadProducto.ToString() ?? "0";
                return Ok(media.Id + "_" + media.Name + "_" + existencia + "_" + media.EstaEnPromocion);
                
            }
            else 
            {
                return NotFound("Media No Encontrada");
            }
        }

        public IActionResult CrearFactura([FromForm] FacturaEncModel model)
        {
            model.Detalles = JsonConvert.DeserializeObject<List<FacturaDetalleModel>>(model.DetalleString);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var facturaEnc = new FacturaEnc { 
                Cliente = _dbContext.Cliente.FirstOrDefault(x => x.Celular == model.Cliente.ToString()),
                TipoEnvio = _dbContext.TipoEnvio.FirstOrDefault(x => x.Id == model.TipoEnvio),
                MedioPago = _dbContext.MedioPago.FirstOrDefault(x => x.Id == model.MedioPago),
                EstadoFactu = _dbContext.EstadosFactu.FirstOrDefault(x => x.Id == model.EstadoFactu),
                FechaPago = model.FechaPago,
                //Total = model.Total,
                FechaCreado = DateTime.Now,
                CreadoPorUser = userId
            };

            if (!string.IsNullOrEmpty(model.Total))
            {
                facturaEnc.Total = int.Parse(model.Total.Replace(".", "").Replace(",", ""));
            }

            foreach (var detalleModel in model.Detalles)
            {
                var media = _dbContext.Medias.FirstOrDefault(m => m.Id == detalleModel.Media);
                var factuDetalle = new FacturaDetalle()
                {
                    Media = media,
                    PrecioUnitario = detalleModel.PrecioUnitario,
                    Cantidad = detalleModel.Cantidad,
                    //Total = detalleModel.Total
                };

                if (!string.IsNullOrEmpty(detalleModel.Total))
                {
                    factuDetalle.Total = int.Parse(detalleModel.Total.Replace(".", "").Replace(",", ""));
                }


                facturaEnc.FacturaDetalle.Add(factuDetalle);
                DeleteExistencia(media, detalleModel.Cantidad);
            }

            _dbContext.FacturaEnc.Add(facturaEnc);
            _dbContext.SaveChanges();

            ViewBag.FactuId = facturaEnc.Id;

            return Ok(facturaEnc.Id);
        }

        public void DeleteExistencia(Media media, int cantidad)
        {
            var existencia = _dbContext.Existencias.FirstOrDefault(e => e.MediaRef == media.Id);
            if (existencia == null)
            {
                _dbContext.Existencias.Add(new Existencias
                {
                    MediaRef = media.Id,
                    CantidadProducto = (cantidad * -1)

                });
            }
            else
            {
                existencia.CantidadProducto -= cantidad;
                _dbContext.Existencias.Update(existencia);
            }
        }

        public IActionResult FactuPrint(int id)
        {
            var factu = _dbContext.FacturaEnc
                                  .Include(f => f.Cliente)
                                  .Include(f => f.EstadoFactu)
                                  .Include(f => f.MedioPago)
                                  .Include(f => f.TipoEnvio)
                                  .Include(f => f.FacturaDetalle)
                                  .ThenInclude(d => d.Media)
                                  .FirstOrDefault(x => x.Id == id);
            return View(factu);
        }
    }
}
