using Cars.Core.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cars.Data
{
    public class CarsTARge24Context : IdentityDbContext<IdentityUser>
    {
        public CarsTARge24Context(DbContextOptions<CarsTARge24Context> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
    }
}
