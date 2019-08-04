using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Data.Models;
using TechAndTools.Services.Models;

namespace TechAndTools.Services
{
    public interface ICategoryService
    {
        Task<CategoryServiceModel> CreateCategoryAsync(CategoryServiceModel categoryServiceModel);

        Task<CategoryServiceModel> EditCategoryAsync(CategoryServiceModel categoryServiceModel);

        Task<bool> DeleteAsync(int id);

        CategoryServiceModel GetCategoryById(int id);

        IQueryable<CategoryServiceModel> GetAllCategoriesByMainCategoryIdAsync(int mainCategoryId);

        IQueryable<CategoryServiceModel> GetAllCategories();
    }
}
