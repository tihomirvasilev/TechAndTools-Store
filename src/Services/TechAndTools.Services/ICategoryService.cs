using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Data.Models;

namespace TechAndTools.Services
{
    public interface ICategoryService
    {
        Task<Category> CreateCategoryAsync(string name, string mainCategoryName);
        Task<MainCategory> CreateMainCategoryAsync(string name);
        Task<bool> ChangeMainCategoryAsync(int categoryId, int newMainCategoryId);
        IQueryable<MainCategory> GetAllMainCategories();
        Task<IEnumerable<Category>> GetAllCategoriesByMainCategoryIdAsync(int mainCategoryId);
        IQueryable<Category> GetAllCategories();
    }
}
