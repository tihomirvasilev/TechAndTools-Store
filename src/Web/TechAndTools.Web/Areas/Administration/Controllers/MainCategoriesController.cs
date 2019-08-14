using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using TechAndTools.Web.InputModels.MainCategories;
using TechAndTools.Web.ViewModels.MainCategories;

namespace TechAndTools.Web.Areas.Administration.Controllers
{
    public class MainCategoriesController : AdministrationController
    {
        private readonly ICategoryService categoryService;
        private readonly IMainCategoryService mainCategoryService;

        public MainCategoriesController(ICategoryService categoryService, IMainCategoryService mainCategoryService)
        {
            this.categoryService = categoryService;
            this.mainCategoryService = mainCategoryService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MainCategoryInputModel model)
        {
            await this.mainCategoryService.CreateAsync(model.To<MainCategoryServiceModel>());

            return this.Redirect("All");
        }

        public async Task<IActionResult> Edit(int id)
        {
            MainCategoryEditInputModel mainCategoryEditInputModel = this.mainCategoryService
                .GetMainCategoryById(id)
                .To<MainCategoryEditInputModel>();

            return this.View(mainCategoryEditInputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MainCategoryEditInputModel mainCategoryEditInputModel)
        {
            await this.mainCategoryService.EditAsync(mainCategoryEditInputModel.To<MainCategoryServiceModel>());

            return this.RedirectToAction("All", "MainCategories");
        }

        public async Task<IActionResult> All()
        {
            var mainCategoriesViewModels = await this.mainCategoryService
                .GetAllMainCategories()
                .To<MainCategoryViewModel>()
                .ToListAsync();

            return this.View(mainCategoriesViewModels);
        }

        public async Task<IActionResult> Delete(int id)
        {
            MainCategoryDeleteViewModel mainCategoryDeleteViewModel = this.mainCategoryService
                .GetMainCategoryById(id)
                .To<MainCategoryDeleteViewModel>();

            return this.View(mainCategoryDeleteViewModel);
        }

        [HttpPost]
        [Route("/Administration/MainCategories/Delete/{id}")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await this.mainCategoryService.DeleteAsync(id);

            return this.RedirectToAction("All", "MainCategories");
        }
    }
}