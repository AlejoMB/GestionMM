using Domain;
using Domain.Models.Informes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
    public class InformesController : Controller
    {
        private GestionDbContext _dbContext;

        public InformesController(GestionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var anoInicial = 2024;

            var listaAnos = new List<SelectListItem>();
            for (int year = anoInicial; year <= DateTime.Now.Year; year++)
            {
                listaAnos.Add(new SelectListItem { Value = $"{year}", Text = $"{year}" });
            }
            ViewBag.DropDownOptions = listaAnos;

            var informes = new InformesModel();
            return View(informes);
        }

        [HttpPost]
        public IActionResult Index(InformesModel model)
        {
            var informes = new InformesModel();
            if (!string.IsNullOrWhiteSpace(model.txtAnoValue) && !string.IsNullOrWhiteSpace(model.txtMesValue))
            {
                int mes = int.Parse(model.txtMesValue);
                int ano = int.Parse(model.txtAnoValue);
                informes.Facturas = new List<InformeEncFactu>();
                var facturas = _dbContext.FacturaEnc.Where(f => f.FechaCreado.Month == mes && f.FechaCreado.Year == ano).Include(f => f.FacturaDetalle).ThenInclude(fDetalle => fDetalle.Media).ToList();

                foreach (var factura in facturas)
                {
                    var encabezado = new InformeEncFactu() { IdFactu = factura.Id, TotalVenta = factura.Total };

                    foreach (var detalleFactu in factura.FacturaDetalle)
                    {
                        var detalle = new InformeFactuDetalle()
                        {
                            idMedia = detalleFactu.Media.Id,
                            PrecioVenta = detalleFactu.PrecioUnitario,
                            Cantidad = detalleFactu.Cantidad,
                            TotalVenta = detalleFactu.Total
                        };

                        detalle.PrecioCompra = GetPrecioCompra(detalle.idMedia);
                        detalle.TotalACosto = detalle.PrecioCompra * detalle.Cantidad;
                        encabezado.TotalACosto += detalle.TotalACosto;
                    }

                    encabezado.TotalGanancia = encabezado.TotalVenta - encabezado.TotalACosto;
                    informes.Facturas.Add(encabezado);
                }
                informes.TotalGananciaMes = informes.Facturas.Sum(f => f.TotalGanancia);
                informes.TotalVentaMes = informes.Facturas.Sum(f => f.TotalVenta);
                informes.TotalACostoMes = informes.Facturas.Sum(f => f.TotalACosto);

                informes.TotalGastos = _dbContext.Gastos.Where(g => g.Fecha.Month == mes && g.Fecha.Year == ano).Sum(g => g.Valor);
            }

            


            var anoInicial = 2024;

            var listaAnos = new List<SelectListItem>();
            for (int year = anoInicial; year <= DateTime.Now.Year; year++)
            {
                listaAnos.Add(new SelectListItem { Value = $"{year}", Text = $"{year}" });
            }


            ViewBag.DropDownOptions = listaAnos;


            return View(informes);
        }

        public int GetPrecioCompra(int idMedia)
        {
            ///Calcular prorateo
            var compras = _dbContext.ComprasDetalle.Where(c => c.Media.Id == idMedia).ToList();

            var totalCostoUnt = compras.Sum(c => c.CostoUnitario);
            var cant = compras.Count;

            return totalCostoUnt / cant;
        }
    }
}
