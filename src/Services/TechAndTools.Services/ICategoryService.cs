using System.Collections.Generic;
using System.Threading.Tasks;
using TechAndTools.Data.Models;

namespace TechAndTools.Services
{
    public interface ICategoryService
    {
        Task<Category> CreateCategoryAsync(string name, int mainCategoryId);
        Task<MainCategory> CreateMainCategoryAsync(string name);
        Task<bool> ChangeMainCategoryAsync(int categoryId, int newMainCategoryId);
        Task<IEnumerable<MainCategory>> GetAllMainCategoriesAsync();
        Task<IEnumerable<Category>> GetAllCategoriesByMainCategoryIdAsync(int mainCategoryId);
    }
}
