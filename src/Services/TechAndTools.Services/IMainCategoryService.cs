using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Services.Models;

namespace TechAndTools.Services
{
    public interface IMainCategoryService
    {
        Task<MainCategoryServiceModel> CreateMainCategoryAsync(MainCategoryServiceModel serviceModel);
        Task<bool> ChangeMainCategoryAsync(int categoryId, int newMainCategoryId);
        IQueryable<MainCategoryServiceModel> GetAllMainCategories();
        MainCategoryServiceModel GetMainCategoryById(int id);
        Task<MainCategoryServiceModel> EditAsync(MainCategoryServiceModel categoryServiceModel);
        Task<bool> DeleteAsync(int id);
    }
}
