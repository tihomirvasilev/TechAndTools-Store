using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.InputModels.MainCategories
{
    public class MainCategoryEditInputModel : IMapFrom<MainCategoryServiceModel>, IMapTo<MainCategoryServiceModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
