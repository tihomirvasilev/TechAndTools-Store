using System.Collections.Generic;
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
    public class MainCategoryServiceTests
    {
        public MainCategoryServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public async void CreateMainCategoryAsyncShouldCreateMainCategory()
        {
            
            var options = new DbContextOptionsBuilder<TechAndToolsDbContext>()
                .UseInMemoryDatabase(databaseName: "CreateMainCategoryAsyncShouldCreateMainCategory")
                .Options;

            var dbContext = new TechAndToolsDbContext(options);

            IMainCategoryService mainCategoryService = new MainCategoryService(dbContext);

            await mainCategoryService.CreateMainCategoryAsync(new MainCategoryServiceModel{Name = "PC"});
            await mainCategoryService.CreateMainCategoryAsync(new MainCategoryServiceModel{Name = "Tools"});

            MainCategory first = dbContext.MainCategories.First();
            MainCategory second = dbContext.MainCategories.Last();

            Assert.Equal(2, dbContext.MainCategories.Count());
            Assert.Equal("PC", first.Name);
            Assert.Equal("Tools", second.Name);
            Assert.NotNull(first);
            Assert.NotNull(first.Categories);
            Assert.NotNull(second);
            Assert.NotNull(second.Categories);
        }

        [Fact]
        public async void GetAllMainCategoriesAsyncShouldReturnAllMainCategories()
        {

            var options = new DbContextOptionsBuilder<TechAndToolsDbContext>()
                .UseInMemoryDatabase(databaseName: "GetAllMainCategoriesAsyncShouldReturnAllMainCategories")
                .Options;

            var dbContext = new TechAndToolsDbContext(options);

            var first = new MainCategory
            {
                Name = "PC1"
            };

            var second = new MainCategory
            {
                Name = "PC2"
            };

            await dbContext.MainCategories.AddAsync(first);
            await dbContext.MainCategories.AddAsync(second);
            await dbContext.SaveChangesAsync();

            IMainCategoryService mainCategoryService = new MainCategoryService(dbContext);

            IEnumerable<MainCategoryServiceModel> mainCategories = mainCategoryService.GetAllMainCategories();

            Assert.NotNull(mainCategories);
            Assert.Equal(2, mainCategories.Count());
            Assert.Equal("PC1", mainCategories.First().Name);
            Assert.Equal("PC2", mainCategories.Last().Name);
        }
    }
}
