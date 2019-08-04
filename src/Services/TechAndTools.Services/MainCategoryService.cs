using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Data;
using TechAndTools.Data.Models;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Services
{
    public class MainCategoryService : IMainCategoryService
    {
        private readonly TechAndToolsDbContext context;

        public MainCategoryService(TechAndToolsDbContext context)
        {
            this.context = context;
        }

        private MainCategory GetMainCategoryByName(string mainCategoryName)
        {
            return this.context.MainCategories.FirstOrDefault(x => x.Name == mainCategoryName);
        }

        public async Task<MainCategoryServiceModel> CreateMainCategoryAsync(MainCategoryServiceModel serviceModel)
        {
            MainCategory mainCategory = serviceModel.To<MainCategory>();

            await this.context.MainCategories.AddAsync(mainCategory);
            await this.context.SaveChangesAsync();

            return serviceModel;
        }

        public async Task<bool> ChangeMainCategoryAsync(int categoryId, int newMainCategoryId)
        {
            Category category = this.context.Categories.Find(categoryId);

            category.MainCategoryId = newMainCategoryId;

            this.context.Update(category);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<MainCategoryServiceModel> EditAsync(MainCategoryServiceModel categoryServiceModel)
        {
            var category = categoryServiceModel.To<MainCategory>();
            this.context.Update(category);
            await this.context.SaveChangesAsync();

            return categoryServiceModel;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            MainCategory mainCategory = await this.context.MainCategories.SingleOrDefaultAsync(x => x.Id == id);

            if (mainCategory == null)
            {
                throw new ArgumentNullException(nameof(mainCategory));
            }

            this.context.MainCategories.Remove(mainCategory);

            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<MainCategoryServiceModel> GetAllMainCategories()
        {
            return this.context.MainCategories.To<MainCategoryServiceModel>();
        }

        public MainCategoryServiceModel GetMainCategoryById(int id)
        {
            return this.context.MainCategories.FirstOrDefault(x => x.Id == id).To<MainCategoryServiceModel>();
        }
    }
}
