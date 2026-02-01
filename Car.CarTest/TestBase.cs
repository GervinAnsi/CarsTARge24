using Cars.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace Cars.CarTest
{
    public abstract class TestBase
    {

        protected CarsTARge24Context GetInMemoryDb()
        {
            var options = new DbContextOptionsBuilder<CarsTARge24Context>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new CarsTARge24Context(options);
        }
    }
}
