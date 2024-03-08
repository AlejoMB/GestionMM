using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class InventarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddProducto()
        {
            return View();
        }
    }
}
