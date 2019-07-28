using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TechAndTools.Services;
using TechAndTools.Services.Mapping;
using TechAndTools.Web.InputModels.Administration.Categories;
using TechAndTools.Web.ViewModels.Administration.MainCategories;

namespace TechAndTools.Web.Areas.Administration.Controllers
{
    public class MainCategoriesController : AdministrationController
    {private readonly ICategoryService categoryService;

        public MainCategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(MainCategoryInputModel model)
        {
            await this.categoryService.CreateMainCategoryAsync(model.Name);

            return this.Redirect("All");
        }

        public async Task<IActionResult> All()
        {
            var mainCategoriesViewModels =
                await this.categoryService.GetAllMainCategories().To<MainCategoryViewModel>().ToListAsync();

            return this.View(mainCategoriesViewModels);
        }
    }
}