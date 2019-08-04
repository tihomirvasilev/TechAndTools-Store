using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;

namespace TechAndTools.Web.ViewModels.Administration.MainCategories
{
    public class MainCategoryViewModel : IMapFrom<MainCategoryServiceModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
