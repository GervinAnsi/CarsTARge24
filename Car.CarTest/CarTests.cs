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

        
    }
}
