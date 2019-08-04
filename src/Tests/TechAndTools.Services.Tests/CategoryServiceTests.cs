using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
    public class CategoryServiceTests
    {
        private List<Category> GetCategoriesData()
        {
            return new List<Category>
            {
                new Category
                {
                    Name = "category1",
                    MainCategoryId = 1
                },
                new Category
                {
                    Name = "category2",
                    MainCategoryId = 1
                }
            };
        }

        private List<MainCategory> GetMainCategoriesData()
        {
            return new List<MainCategory>
            {
                new MainCategory
                {
                    Id = 1,
                    Name = "PC"
                },
                new MainCategory
                {
                    Id = 2,
                    Name = "PC2"
                }
            };
        }

        private async Task SeedData(TechAndToolsDbContext context)
        {
            context.AddRange(GetCategoriesData());
            context.AddRange(GetMainCategoriesData());
            await context.SaveChangesAsync();
        }

        public CategoryServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public async void CreateCategoryAsyncShouldCreateCategory()
        {
            var options = new DbContextOptionsBuilder<TechAndToolsDbContext>()
                .UseInMemoryDatabase(databaseName: "GetAllCategoriesByMainCategoryIdAsyncShouldReturnAllCategoriesWithSameMainCategory")
                .Options;

            var dbContext = new TechAndToolsDbContext(options);
            
            dbContext.Database.EnsureDeleted();

            var mainCategory = new MainCategory
            {
                Id = 1,
                Name = "PC"
            };

            await dbContext.MainCategories.AddAsync(mainCategory);
            await dbContext.SaveChangesAsync();

            ICategoryService categoryService = new CategoryService(dbContext);

            await categoryService.CreateCategoryAsync(new CategoryServiceModel { Name = "category1", MainCategoryId = 1 });
            await categoryService.CreateCategoryAsync(new CategoryServiceModel { Name = "category2", MainCategoryId = 1 });

            Category first = dbContext.Categories.First();
            Category second = dbContext.Categories.Last();

            Assert.Equal(2, dbContext.Categories.Count());
            Assert.Equal(1, first.MainCategoryId);
            Assert.Equal(1, second.MainCategoryId);
            Assert.NotNull(first);
            Assert.NotNull(second);
            Assert.NotNull(first.Products);
            Assert.NotNull(second.Products);
            Assert.NotNull(first.MainCategory);
            Assert.NotNull(second.MainCategory);
        }

        [Fact]
        public async void GetAllCategoriesByMainCategoryIdAsyncShouldReturnAllCategoriesWithSameMainCategory()
        {

            var options = new DbContextOptionsBuilder<TechAndToolsDbContext>()
                .UseInMemoryDatabase(databaseName: "GetAllCategoriesByMainCategoryIdAsyncShouldReturnAllCategoriesWithSameMainCategory")
                .Options;

            var dbContext = new TechAndToolsDbContext(options);

            var mainCategory = new MainCategory
            {
                Name = "PC1"
            };

            var category1 = new Category
            {
                Name = "category1",
                MainCategoryId = 1
            };

            var category2 = new Category
            {
                Name = "category2",
                MainCategoryId = 1
            };

            await dbContext.MainCategories.AddAsync(mainCategory);
            await dbContext.Categories.AddAsync(category1);
            await dbContext.Categories.AddAsync(category2);
            await dbContext.SaveChangesAsync();

            ICategoryService categoryService = new CategoryService(dbContext);

            IEnumerable<CategoryServiceModel> categories = categoryService.GetAllCategoriesByMainCategoryId(1);

            Assert.NotNull(categories);
            Assert.True(categories.Count() == 2);
            Assert.Equal("PC1", categories.First().MainCategory.Name);
            Assert.Equal("PC1", categories.Last().MainCategory.Name);
        }

        [Fact]
        public async Task EditCategoryAsyncShouldEditCategory()
        {


            var options = new DbContextOptionsBuilder<TechAndToolsDbContext>()
                .UseInMemoryDatabase(databaseName: "EditCategoryAsyncShouldEditCategory")
                .Options;

            var dbContext = new TechAndToolsDbContext(options);

            await SeedData(dbContext);

            ICategoryService categoryService = new CategoryService(dbContext);

            CategoryServiceModel expectedData = dbContext.Categories.Find(1).To<CategoryServiceModel>();

            expectedData.Name = "newName";
            expectedData.MainCategoryId = 2;

            await categoryService.EditCategoryAsync(expectedData);

            var actualData = dbContext.Categories.Find(1);

            Assert.True(expectedData.Name == actualData.Name);
            Assert.True(expectedData.MainCategoryId == actualData.MainCategoryId);
            Assert.NotNull(actualData.MainCategory);
            Assert.NotNull(actualData.Products);
        }
    }
}
