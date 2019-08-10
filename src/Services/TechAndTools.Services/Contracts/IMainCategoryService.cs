using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Services.Models;

namespace TechAndTools.Services.Contracts
{
    public interface IMainCategoryService
    {
        Task<MainCategoryServiceModel> CreateAsync (MainCategoryServiceModel serviceModel);

        IQueryable<MainCategoryServiceModel> GetAllMainCategories();

        MainCategoryServiceModel GetMainCategoryById(int id);

        Task<MainCategoryServiceModel> EditAsync(MainCategoryServiceModel mainCategoryServiceModel);

        Task<bool> DeleteAsync(int id);
    }
}
