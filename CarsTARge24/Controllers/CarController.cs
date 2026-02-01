using AspNetCoreGeneratedDocument;
using Cars.Core.ServiceInterface;
using Cars.Data;
using CarsTARge24.Models.Cars;
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
            var result = _context.Cars
                .Select(x => new CarsIndexViewModel()
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    Model = x.Model,
                    FuelType = x.FuelType,
                    Power = x.Power,
                    Drivetrain = x.Drivetrain,
                    Info = x.Info,

                });
            
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("CreateUpdate", new CarsCreateUpdateViewModel());
        }
    }
}
