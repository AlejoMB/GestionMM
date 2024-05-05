using Domain;
using Domain.Entities.Facturacion;
using Domain.Entities.Inventario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Controllers
{
    public class FacturacionController : Controller
    {
        private GestionDbContext _dbContext;

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

            return View();
        }

        [HttpGet]
        public IActionResult GetCliente(string cedula)
        {
            var cliente = _dbContext.Cliente.FirstOrDefault(c => c.Cedula == cedula);
            return cliente == null ? NotFound() : Ok(cliente);
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
    }
}
