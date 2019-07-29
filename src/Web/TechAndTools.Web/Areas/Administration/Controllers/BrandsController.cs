using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechAndTools.Services;
using TechAndTools.Services.Mapping;
using TechAndTools.Web.InputModels.Administration.Brands;
using TechAndTools.Web.ViewModels.Administration.Brands;

namespace TechAndTools.Web.Areas.Administration.Controllers
{
    public class BrandsController : AdministrationController
    {
        private readonly IBrandService brandService;

        public BrandsController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        public IActionResult All()
        {
            var viewModels = this.brandService.GetAllBrands().To<BrandIndexViewModel>();

            return this.View(viewModels);
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(BrandInputModel brandInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Add();
            }

            await this.brandService.CreateBrandAsync(brandInputModel.Name, brandInputModel.LogoUrl, brandInputModel.LogoUrl);

            return this.Redirect("/");
        }

        public IActionResult Details(int id)
        {
            var model = Mapper.Map<BrandDetailsViewModel>(this.brandService.GetBrandById(id));

            return this.View(model);
        }

        public IActionResult Edit()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Edit(int id)
        {
            //TODO: Implement
            return this.Redirect("All");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            //TODO: Implement
            return this.Redirect("All");
        }
    }
}