using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechAndTools.Services;
using TechAndTools.Services.Mapping;
using TechAndTools.Web.InputModels.Administration.Categories;
using TechAndTools.Web.ViewModels.Administration.Categories;
using TechAndTools.Web.ViewModels.Administration.MainCategories;

namespace TechAndTools.Web.Areas.Administration.Controllers
{
    public class CategoriesController : AdministrationController
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Add()
        {
            this.ViewData["mainCategories"] = this.categoryService.GetAllMainCategories().To<AddCategoryMainCategoryViewModel>();

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }
            await this.categoryService.CreateCategoryAsync(inputModel.Name, inputModel.MainCategory);

            return this.Redirect("All");
        }

        public async Task<IActionResult> All()
        {
            var categoriesViewModels = this.categoryService.GetAllCategories().To<CategoryViewModel>();

            return this.View(categoriesViewModels);
        }
    }
}