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

            var context = new TechAndToolsDbContext(options);

            await SeedData(context);

            ICategoryService categoryService = new CategoryService(context);

            MainCategory mainCategoryFromDb = context.MainCategories.First();

            IEnumerable<CategoryServiceModel> categories = categoryService.GetAllCategoriesByMainCategoryId(mainCategoryFromDb.Id);

            Assert.NotNull(categories);
            Assert.True(categories.Count() == 2);
            Assert.Equal(mainCategoryFromDb.Name, categories.First().MainCategory.Name);
            Assert.Equal(mainCategoryFromDb.Id, categories.First().MainCategory.Id);
            Assert.Equal(mainCategoryFromDb.Name, categories.Last().MainCategory.Name);
            Assert.Equal(mainCategoryFromDb.Id, categories.Last().MainCategory.Id);
        }

        [Fact]
        public async Task EditCategoryAsyncShouldEditCategoryById()
        {
            var options = new DbContextOptionsBuilder<TechAndToolsDbContext>()
                .UseInMemoryDatabase(databaseName: "EditCategoryAsyncShouldEditCategoryById")
                .Options;

            var dbContext = new TechAndToolsDbContext(options);

            await SeedData(dbContext);

            ICategoryService categoryService = new CategoryService(dbContext);

            Category expectedData = dbContext.Categories.First();

            expectedData.Name = "newName";
            expectedData.MainCategoryId = 2;

            await categoryService.EditCategoryAsync(expectedData.To<CategoryServiceModel>());

            var actualData = dbContext.Categories.First();

            Assert.True(expectedData.Name == actualData.Name);
            Assert.True(expectedData.MainCategoryId == actualData.MainCategoryId);
            Assert.NotNull(actualData.MainCategory);
            Assert.NotNull(actualData.Products);
        }

        [Fact]
        public async Task DeleteAsyncShouldDeleteCategoryFromDatabase()
        {
            var options = new DbContextOptionsBuilder<TechAndToolsDbContext>()
                .UseInMemoryDatabase(databaseName: "DeleteAsyncShouldDeleteCategoryFromDatabase")
                .Options;

            var context = new TechAndToolsDbContext(options);

            await SeedData(context);

            ICategoryService categoryService = new CategoryService(context);

            Category categoryFromDb = context.Categories.First();

            bool result = await categoryService.DeleteAsync(categoryFromDb.Id);

            Assert.True(result);
            Assert.True(context.Categories.Count() == 1);
        }
        
        [Fact]
        public async Task GetAllCategoriesShouldReturnAllCategoriesAsServiceModels()
        {
            var options = new DbContextOptionsBuilder<TechAndToolsDbContext>()
                .UseInMemoryDatabase(databaseName: "GetAllCategoriesShouldReturnAllCategoriesAsServiceModels")
                .Options;

            var context = new TechAndToolsDbContext(options);

            await SeedData(context);

            ICategoryService categoryService = new CategoryService(context);

            var categoryServiceModels = await categoryService.GetAllCategories().ToListAsync();

            Assert.True(categoryServiceModels.Count == 2);
            Assert.NotNull(categoryServiceModels.First());
            Assert.NotNull(categoryServiceModels.Last());
            Assert.IsType<CategoryServiceModel>(categoryServiceModels.First());
            Assert.IsType<CategoryServiceModel>(categoryServiceModels.Last());
        }

        
        [Fact]
        public async Task GetCategoryByIdShouldReturnCategoryServiceModelById()
        {
            var options = new DbContextOptionsBuilder<TechAndToolsDbContext>()
                .UseInMemoryDatabase(databaseName: "GetCategoryByIdShouldReturnCategoryServiceModelById")
                .Options;

            var context = new TechAndToolsDbContext(options);

            await SeedData(context);

            ICategoryService categoryService = new CategoryService(context);

            Category category = context.Categories.First();

            CategoryServiceModel serviceModel = categoryService.GetCategoryById(category.Id);

            Assert.NotNull(serviceModel);
            Assert.IsType<CategoryServiceModel>(serviceModel);
            Assert.NotNull(serviceModel.MainCategory);
            Assert.NotNull(serviceModel.Products);
        }
    }
}
