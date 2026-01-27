using Cars.Core.ServiceInterface;
using Cars.Data;
using Microsoft.AspNetCore.Mvc;

namespace CarsTARge24.Controllers
{
    public class CarController : Controller
    {
        private readonly CarsTARge24Context _context;
        private readonly ICarServices _carServices;

        public CarController(
            CarsTARge24Context context,
            ICarServices carServices)
        {
            _context = context;
            _carServices = carServices;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
