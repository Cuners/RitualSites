using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using System;
using System.Drawing;
using RitualServer.Model;
namespace WebApplication1.Models
{
    public class TestingWebAppFactory<TEntryPoint> :
WebApplicationFactory<Program1> where TEntryPoint : Program1
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<RitualServer.Model.RitualbdContext>));
                if (descriptor != null)
                    services.Remove(descriptor);
                services.AddDbContext<RitualServer.Model.RitualbdContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryEmployeeTest");
                });
                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                using (var appContext =
                scope.ServiceProvider.GetRequiredService<RitualServer.Model.RitualbdContext>())
                {
                    try
                    {
                        appContext.Database.EnsureCreated();
                        Seed(appContext);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            });

        }
        private void Seed(RitualServer.Model.RitualbdContext context)
        {
            var oneColor = new RitualServer.Model.Color
            {
                ColorId=6,
                Name = "Синий",
            };

            var twoColor = new RitualServer.Model.Color
            {
                ColorId = 7,
                Name = "Красный",
            };

            var threeColor = new RitualServer.Model.Color
            {
                ColorId = 8,
                Name = "Черный",
            };
            var fourColor = new RitualServer.Model.Color
            {
                ColorId = 9,
                Name = "Серый",
            };
            var oneMaterial = new RitualServer.Model.Color
            {
                ColorId = 10,
                Name = "Гранит",
            };

            var twoMaterial = new RitualServer.Model.Color
            {
                ColorId = 2,
                Name = "Камень",
            };

            var threeMaterial = new RitualServer.Model.Color
            {
                ColorId = 3,
                Name = "Дерево",
            };
            var fourMaterial = new RitualServer.Model.Color
            {
                ColorId = 4,
                Name = "Кирпич",
            };
            var oneCategory = new Category
            {
                CategoryId=1,
                Name="Гробы",
                Image=null
            };
            var oneProduct = new Product
            {
                ProductId=1,
                Name="Гроб",
                Price=1000,
                Opisanie="hopa",
                CategoryId=1
            };
            var oneCoffin = new Coffin
            {
                CoffinId = 1,
                ColorId =1,
                MaterialId=1,
                Width=100,
                Height=100,
                Length=100,
                ProductId=1,
                Image=null
            };
            context.AddRange();
            context.SaveChanges();
        }
    }
}
