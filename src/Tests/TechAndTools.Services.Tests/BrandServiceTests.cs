using Microsoft.EntityFrameworkCore;
using System.Linq;
using TechAndTools.Data;
using TechAndTools.Data.Models;
using Xunit;

namespace TechAndTools.Services.Tests
{
    public class BrandServiceTests
    {
        [Fact]
        public async void CreateBrandAsyncShouldCreateBrand()
        {
            var options = new DbContextOptionsBuilder<TechAndToolsDbContext>()
                .UseInMemoryDatabase(databaseName: "Brands_CreateBrand")
                .Options;

            TechAndToolsDbContext dbContext = new TechAndToolsDbContext(options);

            BrandService brandService = new BrandService(dbContext);

            await brandService.CreateBrandAsync("name1", "logo1", "officialSite1");
            await brandService.CreateBrandAsync("name2", "logo2", "officialSite2");

            int brandsCount = await dbContext.Brands.CountAsync();

            Assert.Equal(2, brandsCount);
        }

        [Fact]
        public async void GetAllBrandsShouldReturnAllBrands()
        {
            var options = new DbContextOptionsBuilder<TechAndToolsDbContext>()
                .UseInMemoryDatabase(databaseName: "Brands_GetAllBrands")
                .Options;

            TechAndToolsDbContext dbContext = new TechAndToolsDbContext(options);

            BrandService brandService = new BrandService(dbContext);

            await brandService.CreateBrandAsync("name1", "logo1", "officialSite1");
            await brandService.CreateBrandAsync("name2", "logo2", "officialSite2");

            var brands = await brandService.GetAllBrands().ToListAsync();

            Assert.Equal(2, brands.Count());
            Assert.Equal("name1", brands.First().Name);
            Assert.Equal("name2", brands.Last().Name);
        }

        [Fact]
        public void GetBrandByIdShouldReturnBrandWithSameId()
        {
            var options = new DbContextOptionsBuilder<TechAndToolsDbContext>()
                .UseInMemoryDatabase(databaseName: "Brands_GetBrandById")
                .Options;

            
            TechAndToolsDbContext dbContext = new TechAndToolsDbContext(options);

            BrandService brandService = new BrandService(dbContext);

            Brand brandForDb = new Brand
            {
                Id = 20,
                Name = "name1",
                LogoUrl = "logo1",
                OfficialSite = "officialSite1"
            };

            dbContext.Brands.Add(brandForDb);
            dbContext.SaveChanges();

            Brand brand = brandService.GetBrandById(20);

            Assert.Equal(20, brand.Id);
            Assert.NotNull(brand.Products);
            Assert.NotNull(brand);
        }
    }
}
