using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechAndTools.Data;
using TechAndTools.Data.Models;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using TechAndTools.Services.Tests.Common;
using Xunit;

namespace TechAndTools.Services.Tests
{
    public class BrandServiceTests
    {
        public BrandServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public async void CreateBrandAsyncShouldCreateBrand()
        {
            var options = new DbContextOptionsBuilder<TechAndToolsDbContext>()
                .UseInMemoryDatabase(databaseName: "Brands_CreateBrand")
                .Options;

            TechAndToolsDbContext dbContext = new TechAndToolsDbContext(options);

            BrandService brandService = new BrandService(dbContext);

            await brandService.CreateAsync(new BrandServiceModel {Name = "name1", LogoUrl = "Logo1", OfficialSite = "Site1"});

            await brandService.CreateAsync(new BrandServiceModel {Name = "name2", LogoUrl = "Logo2", OfficialSite = "Site2"});

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

            await brandService.CreateAsync(new BrandServiceModel {Name = "name1", LogoUrl = "Logo1", OfficialSite = "Site1"});
            await brandService.CreateAsync(new BrandServiceModel {Name = "name2", LogoUrl = "Logo2", OfficialSite = "Site2"});

            var brands = await brandService.GetAllBrands().ToListAsync();

            Assert.Equal(2, brands.Count());
            Assert.Equal("name1", brands.First().Name);
            Assert.Equal("name2", brands.Last().Name);
        }

        [Fact]
        public async void GetBrandByIdShouldReturnBrandWithSameId()
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

            BrandServiceModel serviceModel = await brandService.GetBrandByIdAsync(20);

            Brand brand = serviceModel.To<Brand>();

            Assert.Equal(20, brand.Id);
            Assert.NotNull(brand.Products);
            Assert.NotNull(brand);
        }
    }
}
