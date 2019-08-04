using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.ViewModels.Administration.MainCategories
{
    public class MainCategoryDeleteViewModel : IMapFrom<MainCategoryServiceModel>, IMapTo<MainCategoryServiceModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
