using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Web.ViewModels.Categories;

namespace TechAndTools.Web.ViewComponents
{
    public class CategoriesFilterViewComponent : ViewComponent
    {
        private readonly ICategoryService categoryService;

        public CategoriesFilterViewComponent(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categoryViewModels = this.categoryService.GetAllCategories()
                .To<CategoryListViewModel>()
                .ToList();

            return this.View(categoryViewModels);
        }
    }
}
