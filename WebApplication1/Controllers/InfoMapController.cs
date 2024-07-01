using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class InfoMapController : Controller
    {
        public InfoMapController()
        {

        }
        public IActionResult Cemetries()
        {
            return View();
        }
        public IActionResult Morgues()
        {
            return View();
        }
    }
}
