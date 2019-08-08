using System.Collections.Generic;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using TechAndTools.Web.ViewModels.Categories;

namespace TechAndTools.Web.ViewModels.MainCategories
{
    public class MainCategoryComponentViewModel : IMapFrom<MainCategoryServiceModel>
    {
        public string Name { get; set; }

        public ICollection<CategoryComponentViewModel> Categories { get; set; }
    }
}
