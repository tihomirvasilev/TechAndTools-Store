using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechAndTools.Data;
using TechAndTools.Data.Models;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using Xunit;

namespace TechAndTools.Services.Tests
{
    public class CategoryServiceTests
    {
        [Fact]
        public async void CreateMainCategoryAsyncShouldCreateMainCategory()
        {
            
            var options = new DbContextOptionsBuilder<TechAndToolsDbContext>()
                .UseInMemoryDatabase(databaseName: "Categories_CreateMainCategoryAsync")
                .Options;

            var dbContext = new TechAndToolsDbContext(options);

            IMainCategoryService categoryService = new MainCategoryService(dbContext);

            MainCategory first = categoryService.CreateMainCategoryAsync(new MainCategoryServiceModel{Name = "PC"}).GetAwaiter().To<MainCategory>();
            MainCategory second = categoryService.CreateMainCategoryAsync(new MainCategoryServiceModel{Name = "Tools"}).GetAwaiter().To<MainCategory>();

            Assert.Equal(2, dbContext.MainCategories.Count());
            Assert.Equal("PC", first.Name);
            Assert.Equal("Tools", second.Name);
            Assert.NotNull(first);
            Assert.NotNull(first.Categories);
            Assert.NotNull(second);
            Assert.NotNull(second.Categories);
        }

        //[Fact]
        //public async void CreateCategoryAsyncShouldCreateCategory()
        //{
        //    var options = new DbContextOptionsBuilder<TechAndToolsDbContext>()
        //        .UseInMemoryDatabase(databaseName: "Categories_CreateCategoryAsync")
        //        .Options;

        //    var dbContext = new TechAndToolsDbContext(options);

        //    var mainCategory = new MainCategory
        //    {
        //        Id = 1,
        //        Name = "PC"
        //    };

        //    await dbContext.MainCategories.AddAsync(mainCategory);
        //    await dbContext.SaveChangesAsync();

        //    ICategoryService categoryService = new CategoryService(dbContext);

        //    Category first = await categoryService.CreateCategoryAsync("first", "PC");
        //    Category second = await categoryService.CreateCategoryAsync("second2", "PC");

        //    Assert.Equal(2, dbContext.Categories.Count());
        //    Assert.Equal(1, first.MainCategoryId);
        //    Assert.Equal(1, second.MainCategoryId);
        //    Assert.NotNull(first);
        //    Assert.NotNull(second);
        //    Assert.NotNull(first.Products);
        //    Assert.NotNull(second.Products);
        //    Assert.NotNull(first.MainCategory);
        //    Assert.NotNull(second.MainCategory);
        //}

        //[Fact]
        //public async void GetAllMainCategoriesAsyncShouldReturnAllMainCategories()
        //{
            
        //    var options = new DbContextOptionsBuilder<TechAndToolsDbContext>()
        //        .UseInMemoryDatabase(databaseName: "Categories_GetAllMainCategoriesAsync")
        //        .Options;

        //    var dbContext = new TechAndToolsDbContext(options);

        //    var first = new MainCategory
        //    {
        //        Name = "PC1"
        //    };

        //    var second = new MainCategory
        //    {
        //        Name = "PC2"
        //    };

        //    await dbContext.MainCategories.AddAsync(first);
        //    await dbContext.MainCategories.AddAsync(second);
        //    await dbContext.SaveChangesAsync();

        //    ICategoryService categoryService = new CategoryService(dbContext);

        //    IEnumerable<MainCategory> mainCategories = categoryService.GetAllMainCategories();

        //    Assert.NotNull(mainCategories);
        //    Assert.Equal(2, mainCategories.Count());
        //    Assert.Equal("PC1", mainCategories.First().Name);
        //    Assert.Equal("PC2", mainCategories.Last().Name);
        //}

        //[Fact]
        //public async void GetAllCategoriesByMainCategoryIdAsyncShouldReturnAllCategoriesWithSameMainCategory()
        //{
            
        //    var options = new DbContextOptionsBuilder<TechAndToolsDbContext>()
        //        .UseInMemoryDatabase(databaseName: "Categories_ GetAllCategoriesByMainCategoryIdAsync")
        //        .Options;

        //    var dbContext = new TechAndToolsDbContext(options);

        //    var mainCategory = new MainCategory
        //    {
        //        Name = "PC1"
        //    };

        //    var category = new Category
        //    {
        //        Name = "category",
        //        MainCategoryId = 1
        //    };

        //    await dbContext.MainCategories.AddAsync(mainCategory);
        //    await dbContext.Categories.AddAsync(category);
        //    await dbContext.SaveChangesAsync();

        //    ICategoryService categoryService = new CategoryService(dbContext);

        //    IEnumerable<Category> categories = await categoryService.GetAllCategoriesByMainCategoryIdAsync(1);

        //    Assert.NotNull(categories);
        //    Assert.Single(categories);
        //    Assert.Equal("PC1", categories.First().MainCategory.Name);
        //}

        //[Fact]
        //public async void ChangeMainCategoryAsyncShouldChangeCategoryMainCategory()
        //{
            
            
        //    var options = new DbContextOptionsBuilder<TechAndToolsDbContext>()
        //        .UseInMemoryDatabase(databaseName: "Categories_ChangeMainCategoryAsync")
        //        .Options;

        //    var dbContext = new TechAndToolsDbContext(options);

        //    var first = new MainCategory
        //    {
        //        Id = 1,
        //        Name = "PC1"
        //    };

        //    var second = new MainCategory
        //    {
        //        Id = 2,
        //        Name = "PC2"
        //    };

        //    var category = new Category
        //    {
        //        Id = 1,
        //        Name = "category",
        //        MainCategoryId = 1
        //    };

        //    await dbContext.MainCategories.AddAsync(first);
        //    await dbContext.MainCategories.AddAsync(second);
        //    await dbContext.Categories.AddAsync(category);
        //    await dbContext.SaveChangesAsync();

        //    ICategoryService categoryService = new CategoryService(dbContext);

        //    await categoryService.ChangeMainCategoryAsync(1, 2);

        //    Category categoryFromDb = dbContext.Categories.Find(1);

        //    Assert.Equal(2, categoryFromDb.MainCategoryId);
        //}
    }
}
