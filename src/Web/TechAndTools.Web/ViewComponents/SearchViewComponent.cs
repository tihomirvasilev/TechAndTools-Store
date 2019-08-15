using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechAndTools.Services;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Web.ViewModels.Categories;

namespace TechAndTools.Web.ViewComponents
{
    public class SearchViewComponent : ViewComponent
    {
        
        private readonly ICategoryService categoryService;

        public SearchViewComponent(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            IEnumerable<CategoryComponentViewModel> mainCategoriesCategoryComponentViewModels = this.categoryService
                .GetAllCategories()
                .To<CategoryComponentViewModel>()
                .ToList();
            
            return this.View(mainCategoriesCategoryComponentViewModels);
        }
    }
}
