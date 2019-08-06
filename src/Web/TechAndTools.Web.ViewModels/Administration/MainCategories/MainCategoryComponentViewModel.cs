using System.Collections.Generic;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using TechAndTools.Web.ViewModels.Administration.Categories;

namespace TechAndTools.Web.ViewModels.Administration.MainCategories
{
    public class MainCategoryComponentViewModel : IMapFrom<MainCategoryServiceModel>
    {
        public string Name { get; set; }

        public ICollection<CategoryComponentViewModel> Categories { get; set; }
    }
}
