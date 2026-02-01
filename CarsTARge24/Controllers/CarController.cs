using AspNetCoreGeneratedDocument;
using Cars.Core.Dto;
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

        [HttpPost]
        public async Task<IActionResult> Create(CarsCreateUpdateViewModel vm)
        {
            var dto = new CarsDto()
            {
                Id = Guid.NewGuid(),
                Brand = vm.Brand,
                Model = vm.Model,
                FuelType = vm.FuelType,
                Power = vm.Power,
                Drivetrain= vm.Drivetrain,
                Info = vm.Info,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt
            };

            var result = await _carServices.Create(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var cars = await _carServices.DetailAsync(id);
            if (cars == null) return NotFound();

            var vm = new CarsCreateUpdateViewModel()
            {
                Id = cars.Id,
                Brand = cars.Brand,
                Model = cars.Model,
                FuelType=cars.FuelType,
                Power = cars.Power,
                Drivetrain = cars.Drivetrain,
                Info = cars.Info,
                CreatedAt= cars.CreatedAt,
                UpdatedAt= cars.UpdatedAt
            };

            return View("CreateUpdate", vm);
        }
    }
}
