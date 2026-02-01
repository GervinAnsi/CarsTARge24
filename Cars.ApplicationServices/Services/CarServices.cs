using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cars.Core.Domain;
using Cars.Core.Dto;
using Cars.Core.ServiceInterface;
using Cars.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Cars.ApplicationServices.Services
{
    public class CarServices : ICarServices
    {
        private readonly CarsTARge24Context _context;

        public CarServices
            (
                CarsTARge24Context context
            )
        {
            _context = context;
        }

        public async Task<Car> Create(CarsDto dto)
        {
            var car = new Car()
            {
                Id = Guid.NewGuid(),
                Brand = dto.Brand,
                Model = dto.Model,
                FuelType = dto.FuelType,
                Power = dto.Power,
                Drivetrain = dto.Drivetrain,
                Info = dto.Info,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> Update(CarsDto dto)
        {
            var car = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (car == null) return null;

            car.Model = dto.Model;
            car.Brand = dto.Brand;
            car.FuelType = dto.FuelType;
            car.Power = dto.Power;
            car.Drivetrain = dto.Drivetrain;
            car.Info = dto.Info;
            car.UpdatedAt = DateTime.UtcNow;

            _context.Cars.Update(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<Car> DetailAsync(Guid id)
        {
            return await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Car> Delete(Guid id)
        {
            var domain = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if (domain == null) return null;

            _context.Cars.Remove(domain);
            await _context.SaveChangesAsync();

            return domain;
        }

        public async Task<List<Car>> GetAllAsync()
        {
            return await _context.Cars.ToListAsync();
        }
    }
}
