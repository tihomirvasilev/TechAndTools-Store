using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TechAndTools.Services;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Web.ViewModels.MainCategories;

namespace TechAndTools.Web.ViewComponents
{
    public class CategoriesNavigationViewComponent : ViewComponent
    {
        private readonly IMainCategoryService mainCategoryService;

        public CategoriesNavigationViewComponent(IMainCategoryService mainCategoryService)
        {
            this.mainCategoryService = mainCategoryService;
        }

        public IViewComponentResult Invoke()
        {
            IEnumerable<MainCategoryComponentViewModel> mainCategoriesCategoryComponentViewModels = this.mainCategoryService
                .GetAllMainCategories()
                .To<MainCategoryComponentViewModel>()
                .ToList();
            
            return this.View(mainCategoriesCategoryComponentViewModels);
        }
    }
}
