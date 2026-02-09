using Cars.ApplicationServices.Services;
using Cars.Core.ServiceInterface;
using Cars.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarsTARge24
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllersWithViews();


            var connectionString = builder.Configuration.GetConnectionString("CarsTARge24Connection");
            builder.Services.AddDbContext<CarsTARge24Context>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddScoped<ICarServices, CarServices>();

            builder.Services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<CarsTARge24Context>();

            var app = builder.Build();


            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<CarsTARge24Context>();
                try
                {
                    if (dbContext.Database.IsRelational())
                    {
                        dbContext.Database.Migrate();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Database migration failed: " + ex);
                }
            }


            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
