using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Data;
using TechAndTools.Data.Models;

namespace TechAndTools.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly TechAndToolsDbContext context;

        public CategoryService(TechAndToolsDbContext context)
        {
            this.context = context;
        }

        public async Task<Category> CreateCategoryAsync(string name, string mainCategoryName)
        {
            var mainCategory = this.GetMainCategoryByName(mainCategoryName);

            Category category = new Category
            {
                Name = name,
                MainCategoryId = mainCategory.Id
            };

            await this.context.Categories.AddAsync(category);
            await this.context.SaveChangesAsync();

            return category;
        }

        private MainCategory GetMainCategoryByName(string mainCategoryName)
        {
            return this.context.MainCategories.FirstOrDefault(x => x.Name == mainCategoryName);
        }

        public async Task<MainCategory> CreateMainCategoryAsync(string name)
        {
            MainCategory mainCategory = new MainCategory
            {
                Name = name
            };

            await this.context.MainCategories.AddAsync(mainCategory);
            await this.context.SaveChangesAsync();

            return mainCategory;
        }

        public async Task<bool> ChangeMainCategoryAsync(int categoryId, int newMainCategoryId)
        {
            Category category = this.context.Categories.Find(categoryId);

            category.MainCategoryId = newMainCategoryId;

            this.context.Update(category);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<MainCategory> GetAllMainCategories()
        {
            return this.context.MainCategories;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesByMainCategoryIdAsync(int mainCategoryId)
        {
            return await this.context.Categories.Where(category => category.MainCategoryId == mainCategoryId).ToListAsync();
        }

        public IQueryable<Category> GetAllCategories()
        {
            return this.context.Categories;
        }
    }
}