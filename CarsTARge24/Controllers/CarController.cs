using Microsoft.AspNetCore.Mvc;

namespace CarsTARge24.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
