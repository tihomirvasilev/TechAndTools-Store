using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechAndTools.Services.Contracts;
using TechAndTools.Services.Mapping;
using TechAndTools.Services.Models;
using TechAndTools.Web.InputModels.Administration.Categories;
using TechAndTools.Web.ViewModels.Categories;
using TechAndTools.Web.ViewModels.MainCategories;

namespace TechAndTools.Web.Areas.Administration.Controllers
{
    public class CategoriesController : AdministrationController
    {
        private readonly ICategoryService categoryService;
        private readonly IMainCategoryService mainCategoryService;

        public CategoriesController(ICategoryService categoryService, IMainCategoryService mainCategoryService)
        {
            this.categoryService = categoryService;
            this.mainCategoryService = mainCategoryService;
        }

        public IActionResult Create()
        {
            this.ViewData["mainCategories"] = this.mainCategoryService
                .GetAllMainCategories()
                .To<CreateCategoryMainCategoryViewModel>();

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateInputModel createInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                this.ViewData["mainCategories"] = this.mainCategoryService
                    .GetAllMainCategories()
                    .To<CreateCategoryMainCategoryViewModel>();

                return this.View();
            }

            await this.categoryService.CreateCategoryAsync(createInputModel.To<CategoryServiceModel>());

            return this.Redirect("All");
        }

        public IActionResult Edit(int id)
        {
            //TODO: change view model

            CategoryEditInputModel editInputModel = this.categoryService
                .GetCategoryById(id)
                .To<CategoryEditInputModel>();

            if(editInputModel == null)
            {
                // TODO: Error Handling
                return this.Redirect("/");
            }

            this.ViewData["mainCategories"] = this.mainCategoryService
                .GetAllMainCategories()
                .To<CreateCategoryMainCategoryViewModel>();

            return this.View(editInputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryEditInputModel editInputModel)
        {
            await this.categoryService.EditCategoryAsync(editInputModel.To<CategoryServiceModel>());

            this.ViewData["mainCategories"] = this.mainCategoryService
                .GetAllMainCategories()
                .To<CreateCategoryMainCategoryViewModel>();

            return this.RedirectToAction("All", "Categories");
        }

        public async Task<IActionResult> Delete(int id)
        {
            CategoryDeleteViewModel categoryDeleteViewModel = this.categoryService
                .GetCategoryById(id)
                .To<CategoryDeleteViewModel>();

            if (categoryDeleteViewModel == null)
            {
                // TODO: Error Handling
                return this.Redirect("All");
            }

            return this.View(categoryDeleteViewModel);
        }

        [HttpPost]
        [Route("/Administration/Categories/Delete/{id}")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await this.categoryService.DeleteAsync(id);

            return this.RedirectToAction("All", "Categories");
        }

        public IActionResult All()
        {
            List<CategoryViewModel> categoriesViewModels = this.categoryService
                .GetAllCategories()
                .To<CategoryViewModel>()
                .ToList();

            return this.View(categoriesViewModels);
        }
    }
}