using Cars.ApplicationServices.Services;
using Cars.CarTest;
using Cars.Core.Domain;
using Cars.Core.Dto;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Cars.CarTest
{ 
    public class CarTests : TestBase
    {
        [Fact]
        public async Task Create_ShouldAddCar()
        {
            // Arrange
            var context = GetInMemoryDb();
            var service = new CarServices(context);

            var dto = new CarsDto()
            {
                Id = Guid.NewGuid(),
                Brand = "TestBrand",
                Model = "TestModel",
                FuelType = "TestFuel",
                Power = 1,
                Drivetrain = "TestDriveTrain",
                Info = "TestCar"
            };

            // Act
            var result = await service.Create(dto);

            // Assert
            var savedCar = await context.Cars.FirstOrDefaultAsync();
            Assert.NotNull(savedCar);
            Assert.Equal("TestBrand", savedCar.Brand);

        }

        [Fact]
        public async Task Update_ShouldModifyCar()
        {
            // Arrange

            var context = GetInMemoryDb();
            var service = new CarServices(context);

            var car = new Car
            {
                Id = Guid.NewGuid(),
                Brand = "TestBrand",
                Model = "TestModel",
                FuelType = "TestFuel",
                Power = 1,
                Drivetrain = "TestDriveTrain",
                Info = "TestCar"
            };
            context.Cars.Add(car);
            await context.SaveChangesAsync();

            var dto = new CarsDto()
            {
                Id = car.Id,
                Brand = "ChangedBrand",
                Model = "ChangedModel"
            };

            // Act
            await service.Update(dto);

            //Assert
            var updatedCar = await context.Cars.FindAsync(car.Id);
            Assert.Equal("ChangedBrand", updatedCar.Brand);
            Assert.Equal("ChangedModel", updatedCar.Model);
        }

        [Fact]
        public async Task Delete_ShouldRemoveCar()
        {
            // Arrange
            var context = GetInMemoryDb();
            var service = new CarServices(context);

            var car = new Car
            { 
                Id = Guid.NewGuid(),
                Brand = "TestBrand",
                Model = "TestModel" 
            };

            context.Cars.Add(car);
            await context.SaveChangesAsync();

            // Act
            await service.Delete(car.Id);

            // Assert
            var deletedCar = await context.Cars.FindAsync(car.Id);
            Assert.Null(deletedCar);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllCars()
        {
            // Arrange
            var context = GetInMemoryDb();
            var service = new CarServices(context);

            context.Cars.Add(new Car { Id = Guid.NewGuid(), Brand = "Honda", Model = "Civic" });
            context.Cars.Add(new Car { Id = Guid.NewGuid(), Brand = "Mazda", Model = "3" });
            await context.SaveChangesAsync();

            // Act
            var cars = await service.GetAllAsync();

            // Assert
            Assert.Equal(2, cars.Count);
            Assert.Contains(cars, c => c.Brand == "Honda");
            Assert.Contains(cars, c => c.Brand == "Mazda");
        }



    }
}
