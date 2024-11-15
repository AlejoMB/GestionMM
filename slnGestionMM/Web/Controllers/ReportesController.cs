using Domain;
using Domain.Entities.Gastos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Web.ViewModels;

namespace Web.Controllers
{
    public class ReportesController : Controller
    {
        private readonly GestionDbContext _context;
        public ReportesController(GestionDbContext context) {
            _context = context;
        }
        

        public IActionResult Index()
        {
            var model = new ReporteCalendarModel();
            model.Calendario = new List<List<DateTime>>();
            model.VentasPorDia = new Dictionary<DateTime, List<Domain.Entities.Facturacion.FacturaEnc>>();

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(ReporteCalendarModel model)
        {
            var inicioMes = new DateTime(DateTime.Now.Year, model.Mes, 1);
            var finMes = inicioMes.AddMonths(1).AddDays(-1);

            var ventasPorDia = _context.FacturaEnc
                .Where(f => f.FechaCreado >= inicioMes && f.FechaCreado <= finMes)
                .GroupBy(f => f.FechaCreado.Date)
                .ToDictionary(g => g.Key, g => g.ToList());

            // Generar las semanas del mes
            var diasCalendario = new List<DateTime>();
            var primerDiaSemana = inicioMes.AddDays(-(int)inicioMes.DayOfWeek + 1); // Ajusta al lunes de la primera semana
            for (var dia = primerDiaSemana; dia <= finMes || dia.DayOfWeek != DayOfWeek.Monday; dia = dia.AddDays(1))
            {
                diasCalendario.Add(dia);
            }

            var modeloCalendario = diasCalendario
                .GroupBy(d => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(d, CalendarWeekRule.FirstDay, DayOfWeek.Monday))
                .Select(semana => semana.ToList())
                .ToList();

            model.VentasPorDia = ventasPorDia;
            model.Calendario = modeloCalendario;
            return View(model);
        }

        public IActionResult Ganancias()
        {
            var model = new ReporteVentasModel();
            model.Ventas = new List<IGrouping<int, VentasModel>>();
            model.Gastos = new List<Gastos>();
            model.Inventario = new InventarioModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Ganancias(ReporteVentasModel model)
        {

            model.Ventas = _context.FacturaDetalle
                        .Include(f => f.Encabezado)
                        .Include(d => d.Media)
                        .ThenInclude(m => m.ComprasDetalle)
                        .Where(f => f.Encabezado.FechaCreado.Month == model.Mes)
                        //.Take(5)
                        .OrderBy(f => f.Encabezado.FechaCreado)
                        .Select(v => new VentasModel
                        {
                            IdFactura = v.Encabezado.Id,
                            ValorVenta = v.PrecioUnitario,
                            ValorCompra = v.Media.ComprasDetalle.FirstOrDefault() != null
                                          ? v.Media.ComprasDetalle.Sum(c => c.CostoUnitario) / v.Media.ComprasDetalle.Count
                                          : 0,
                            Cantidad = v.Cantidad,
                            IdMedia = v.Media.Id,
                            TotalCompra = v.Media.ComprasDetalle.FirstOrDefault() != null
                                          ? (v.Media.ComprasDetalle.Sum(c => c.CostoUnitario) / v.Media.ComprasDetalle.Count) * v.Cantidad
                                          : 0,
                            TotalVenta = v.PrecioUnitario * v.Cantidad,
                            TotalGanancias = (v.PrecioUnitario * v.Cantidad) - (v.Media.ComprasDetalle.FirstOrDefault() != null
                                          ? (v.Media.ComprasDetalle.Sum(c => c.CostoUnitario) / v.Media.ComprasDetalle.Count) * v.Cantidad
                                          : 0)
                        }).GroupBy(f => f.IdFactura)
                        .ToList();

            model.Gastos = _context.Gastos.Include(g => g.TipoGasto).Where(x => x.Fecha.Month == model.Mes).OrderBy(g => g.Fecha).ToList();

            model.Inventario = new InventarioModel();
            model.Inventario.CantidadMedias = _context.Existencias. Sum(x => x.CantidadProducto);
            
            var valorTotal = 0;
            var existencias = _context.Existencias.Include(e => e.Media).ThenInclude(m => m.ComprasDetalle).ToList();
            foreach ( var item in existencias)
            {
                valorTotal += item.Media.ComprasDetalle.FirstOrDefault().Cantidad * item.Media.ComprasDetalle.FirstOrDefault().CostoUnitario;
                
            }

            model.Inventario.TotalValor = valorTotal;

            return View(model);
        }
    }
}
