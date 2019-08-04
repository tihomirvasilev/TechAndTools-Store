using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private List<Brand> GetBrandsData()
        {
            return new List<Brand>
            {
                new Brand
                {
                    Id = 1,
                    Name = "brand1",
                    LogoUrl = "logo1",
                    OfficialSite = "site1"
                },
                new Brand
                {
                    Id = 2,
                    Name = "brand2",
                    LogoUrl = "logo2",
                    OfficialSite = "site2"
                }
            };
        }

        private async Task SeedData(TechAndToolsDbContext context)
        {
            context.AddRange(GetBrandsData());
            await context.SaveChangesAsync();
        }

        public BrandServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public async Task CreateBrandAsyncShouldCreateBrand()
        {
            var options = new DbContextOptionsBuilder<TechAndToolsDbContext>()
                .UseInMemoryDatabase(databaseName: "CreateBrandAsyncShouldCreateBrand")
                .Options;

            TechAndToolsDbContext dbContext = new TechAndToolsDbContext(options);

            BrandService brandService = new BrandService(dbContext);

            await brandService.CreateAsync(new BrandServiceModel { Name = "name1", LogoUrl = "Logo1", OfficialSite = "Site1" });

            await brandService.CreateAsync(new BrandServiceModel { Name = "name2", LogoUrl = "Logo2", OfficialSite = "Site2" });

            int brandsCount = await dbContext.Brands.CountAsync();

            Assert.Equal(2, brandsCount);
        }

        [Fact]
        public async Task GetAllBrandsShouldReturnAllBrandsAsServiceModels()
        {
            var options = new DbContextOptionsBuilder<TechAndToolsDbContext>()
                .UseInMemoryDatabase(databaseName: "GetAllBrandsShouldReturnAllBrands")
                .Options;

            TechAndToolsDbContext dbContext = new TechAndToolsDbContext(options);

            await SeedData(dbContext);

            BrandService brandService = new BrandService(dbContext);

            var brandServiceModels = await brandService.GetAllBrands().ToListAsync();

            Assert.Equal(2, brandServiceModels.Count());
            Assert.Equal("brand1", brandServiceModels.First().Name);
            Assert.Equal("brand2", brandServiceModels.Last().Name);
        }

        [Fact]
        public async Task GetBrandByIdShouldReturnBrandServiceModelByBrandId()
        {
            var options = new DbContextOptionsBuilder<TechAndToolsDbContext>()
                .UseInMemoryDatabase(databaseName: "GetBrandByIdShouldReturnBrandWithSameId")
                .Options;

            TechAndToolsDbContext context = new TechAndToolsDbContext(options);

            await SeedData(context);

            BrandService brandService = new BrandService(context);

            Brand expectedData = context.Brands.First();

            BrandServiceModel actualData = await brandService.GetBrandByIdAsync(expectedData.Id);

            Assert.Equal(expectedData.Id, actualData.Id);
            Assert.Equal(expectedData.Name, actualData.Name);
            Assert.Equal(expectedData.LogoUrl, actualData.LogoUrl);
            Assert.Equal(expectedData.OfficialSite, actualData.OfficialSite);
            Assert.NotNull(actualData);
            Assert.NotNull(actualData.Products);
        }

        [Fact]
        public async Task EditBrandAsyncShouldEditBrandById()
        {
            var options = new DbContextOptionsBuilder<TechAndToolsDbContext>()
                .UseInMemoryDatabase(databaseName: "EditBrandAsyncShouldEditBrandById")
                .Options;

            TechAndToolsDbContext context = new TechAndToolsDbContext(options);

            await SeedData(context);

            BrandService brandService = new BrandService(context);

            Brand expectedData = context.Brands.First();

            expectedData.Name = "New Name";
            expectedData.LogoUrl = "New Logo";
            expectedData.OfficialSite = "New Site";

            BrandServiceModel serviceModel = expectedData.To<BrandServiceModel>();

            BrandServiceModel actualData = await brandService.EditAsync(serviceModel);

            Assert.Equal(expectedData.Id, actualData.Id);
            Assert.Equal(expectedData.Name, actualData.Name);
            Assert.Equal(expectedData.LogoUrl, actualData.LogoUrl);
            Assert.Equal(expectedData.OfficialSite, actualData.OfficialSite);
            Assert.NotNull(actualData);
            Assert.NotNull(actualData.Products);
        }

        [Fact]
        public async Task DeleteAsyncShouldDeleteBrandFromDatabaseById()
        {
            
            var options = new DbContextOptionsBuilder<TechAndToolsDbContext>()
                .UseInMemoryDatabase(databaseName: "DeleteAsyncShouldDeleteBrandFromDatabaseById")
                .Options;

            TechAndToolsDbContext context = new TechAndToolsDbContext(options);

            await SeedData(context);

            BrandService brandService = new BrandService(context);

            Brand brandFromDb = context.Brands.First();

            bool result = await brandService.DeleteAsync(brandFromDb.Id);

            Assert.True(result);
        }
    }
}
